using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class TurnGridBuilder : GridBuilder
	{
		public TurnGridBuilder(ISession session, GridDTO values, string defaultSortField) : base(session, values, defaultSortField) { }
		public TurnGridBuilder(ISession session) : base(session) { }
	}
}
