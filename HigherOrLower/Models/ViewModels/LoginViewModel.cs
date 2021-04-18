using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
    /// <summary>
    /// Holds data needed for the Login view
    /// 
    /// Author: Nolan Williams
    /// Date:	4/18/2021
    /// </summary>
    public class LoginViewModel
	{

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
        [StringLength(255)]
        public string Password { get; set; }

		/// <summary>
		/// Gets or sets the return URL.
		/// </summary>
		/// <value>
		/// The return URL.
		/// </value>
		public string ReturnUrl { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [remember me].
		/// </summary>
		/// <value>
		///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
		/// </value>
		public bool RememberMe { get; set; }
    }
}
