using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSphere.Server.DTOs.ReviewDtos
{
    public class ReviewReturnDto
    {
         // Unique identifier for the review
        public int Id { get; set; }

        // Rating given by the client, typically on a scale (e.g., 1 to 5)
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        // Comment or feedback provided by the client
        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public string Comment { get; set; } = string.Empty;

        // Foreign key linking to the Booking that this review is associated with
        public int BookingId { get; set; }
    }
}