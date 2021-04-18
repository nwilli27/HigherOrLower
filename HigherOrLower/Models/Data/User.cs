using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class User : IdentityUser
	{
		[NotMapped]
		public IList<string> RoleNames { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int CurrentGamePlayId { get; set; }
		public int HighScoreGamePlayId { get; set; }
	}
}
