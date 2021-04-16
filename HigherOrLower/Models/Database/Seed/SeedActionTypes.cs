using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class SeedActionTypes : IEntityTypeConfiguration<ActionType>
	{
		public void Configure(EntityTypeBuilder<ActionType> builder)
		{
			builder.HasData(
				new ActionType() { ActionTypeId = 1, Description = "Continue" },
				new ActionType() { ActionTypeId = 2, Description = "Hold" },
				new ActionType() { ActionTypeId = 3, Description = "Game Over" });
		}
	}
}
