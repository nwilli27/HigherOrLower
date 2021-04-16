using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage = "Please eneter a first name.")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please eneter a last name.")]
        [StringLength(255)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter an email in the correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
