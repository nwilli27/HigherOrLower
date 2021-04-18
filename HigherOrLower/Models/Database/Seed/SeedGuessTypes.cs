using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Seeds guess types
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{HigherOrLower.Models.GuessType}" />
	public class SeedGuessTypes : IEntityTypeConfiguration<GuessType>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<GuessType> builder)
		{
			builder.HasData(
				new GuessType() { GuessTypeId = 1, Description = "Higher" },
				new GuessType() { GuessTypeId = 2, Description = "Lower" });
		}
	}
}
