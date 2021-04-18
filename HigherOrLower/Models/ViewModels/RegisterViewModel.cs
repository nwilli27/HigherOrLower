using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
    /// <summary>
    /// Holds data needed for Register View
    /// 
    /// Author: Nolan Williams
    /// Date:	4/18/2021
    /// </summary>
    public class RegisterViewModel
	{

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		[Required(ErrorMessage = "Please eneter a first name.")]
        [StringLength(255)]
        public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		[Required(ErrorMessage = "Please eneter a last name.")]
        [StringLength(255)]
        public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		[EmailAddress(ErrorMessage = "Please enter an email in the correct format")]
        public string Email { get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		[Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		[Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

		/// <summary>
		/// Gets or sets the confirm password.
		/// </summary>
		/// <value>
		/// The confirm password.
		/// </value>
		[Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
