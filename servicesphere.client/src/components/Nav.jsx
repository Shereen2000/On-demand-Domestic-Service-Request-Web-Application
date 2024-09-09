import "../../node_modules/bootstrap/dist/js/bootstrap.bundle.min";
import React from 'react';
import { Link, useNavigate } from 'react-router-dom'; 
import useAuth from '../hooks/useAuth'; 

const Nav = () => {
  const { auth, isLoggedIn, logout } = useAuth(); 
  const navigate = useNavigate();

  const handleLogout = () => {
    logout(); 
    navigate('/'); 
  };

  return (
    <nav className="navbar navbar-expand-md bg-success navbar-light">
      <div className="container">
        <a href="#" className="navbar-brand text-white fw-bold fs-4">ServiceSphere</a>

        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav me-auto">
            <li className="nav-item">
              <Link to="/" className="nav-link text-white fw-semibold fs-5">Home</Link>
            </li>
            <li className="nav-item">
              <Link to="/bookings" className="nav-link text-white fw-semibold fs-5">Bookings</Link>
            </li>
            <li className="nav-item">
              <Link to="/jobs" className="nav-link text-white fw-semibold fs-5">Jobs</Link>
            </li>

            
          </ul>

          <ul className="navbar-nav ms-auto">
            {isLoggedIn ? (
              <>
                <li className="nav-item">
                  <span className="nav-link text-white fs-6">Welcome, {auth.userName}</span>
                </li>
                <li className="nav-item">
                  <button className="btn btn-link text-white fs-6" onClick={handleLogout}>Logout</button>
                </li>
              </>
            ) : (
              <li className="nav-item">
                <Link to="/login" className="nav-link text-white fs-6">Login</Link>
              </li>
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Nav;
