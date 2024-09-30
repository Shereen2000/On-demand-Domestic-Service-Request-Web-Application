using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using ServiceSphere.Server.DTOs;
using ServiceSphere.Server.Models;
using ServiceSphere.Server.Services;

namespace ServiceSphere.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountCreateDto accountCreateDto)
        {
                try {
                    if(!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var appUser = new ApplicationUser
                    {
                        UserName = accountCreateDto.Email,
                        Email = accountCreateDto.Email,
                        Name = accountCreateDto.Name,
                        Surname = accountCreateDto.Surname,
                        IsWorker = false,
                        PhoneNumber = accountCreateDto.PhoneNumber,
                        Role = accountCreateDto.Role
                    };

                    var createdUser = await _userManager.CreateAsync(appUser, accountCreateDto.Password);

                    if(createdUser.Succeeded)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(appUser, accountCreateDto.Role.GetDisplayName());

                        if(roleResult.Succeeded)
                        {
                           // return Ok("User created");
                            return Ok(
                                        new AccountReturnDto
                                        {
                                            UserName = appUser.UserName,
                                            Email = appUser.Email,
                                            Name = appUser.Name,
                                            Surname = appUser.Surname,
                                            PhoneNumber = appUser.PhoneNumber,
                                            IsWorker = appUser.IsWorker,
                                            Role = appUser.Role.GetDisplayName(),
                                            Token = _tokenService.CreateToken(appUser),
                                        }
                                    );
                        }else
                        {
                            return StatusCode(500, roleResult.Errors);
                        }
                    }else
                    {
                        return StatusCode(500, createdUser.Errors);
                    }

                } catch (Exception e)
                {
                    return StatusCode(500,e); //run migration to see roles dotnet ef migrations add seedRole
                }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AccountLoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());


            if(user == null){return Unauthorized("Invalid username");}

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if(!result.Succeeded) {return Unauthorized("UserName not found and/or password incorrect");}

            return Ok(
                new AccountReturnDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

    }
}