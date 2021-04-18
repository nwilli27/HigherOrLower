using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a User
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
	public class User : IdentityUser
	{

		/// <summary>
		/// Gets or sets the role names.
		/// </summary>
		/// <value>
		/// The role names.
		/// </value>
		[NotMapped]
		public IList<string> RoleNames { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the current game play identifier.
		/// </summary>
		/// <value>
		/// The current game play identifier.
		/// </value>
		public int CurrentGamePlayId { get; set; }

		/// <summary>
		/// Gets or sets the high score game play identifier.
		/// </summary>
		/// <value>
		/// The high score game play identifier.
		/// </value>
		public int HighScoreGamePlayId { get; set; }
	}
}
