using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for a GuessType
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class GuessType
	{

		/// <summary>
		/// Gets or sets the guess type identifier.
		/// </summary>
		/// <value>
		/// The guess type identifier.
		/// </value>
		public int GuessTypeId { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description { get; set; }
	}
}
