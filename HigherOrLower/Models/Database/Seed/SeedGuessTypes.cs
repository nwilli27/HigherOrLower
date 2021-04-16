using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	public class SeedGuessTypes : IEntityTypeConfiguration<GuessType>
	{
		public void Configure(EntityTypeBuilder<GuessType> builder)
		{
			builder.HasData(
				new GuessType() { GuessTypeId = 1, Description = "Higher" },
				new GuessType() { GuessTypeId = 2, Description = "Lower" });
		}
	}
}
