using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectWebApp.DTOs
{
    public class UserDto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public int BranchID { get; set; }
    }
}
