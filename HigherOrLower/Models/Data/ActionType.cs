using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class ActionType
	{
		public int ActionTypeId { get; set; }
		public string Description { get; set; }
		public GameActionType Type => (GameActionType) ActionTypeId;
	}
}
