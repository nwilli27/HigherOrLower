using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds types of actions that map to DB values
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	public enum GameActionType
	{
		Start = 1,
		Continue = 2,
		Hold = 3,
		GameOver = 4
	}
}
