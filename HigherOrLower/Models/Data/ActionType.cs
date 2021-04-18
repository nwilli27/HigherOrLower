using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds data for an ActionType
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public class ActionType
	{

		/// <summary>
		/// Gets or sets the action type identifier.
		/// </summary>
		/// <value>
		/// The action type identifier.
		/// </value>
		public int ActionTypeId { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public GameActionType Type => (GameActionType) ActionTypeId;
	}
}
