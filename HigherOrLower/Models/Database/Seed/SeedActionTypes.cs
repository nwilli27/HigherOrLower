using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Seeds action types
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{HigherOrLower.Models.ActionType}" />
	public class SeedActionTypes : IEntityTypeConfiguration<ActionType>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<ActionType> builder)
		{
			builder.HasData(
				new ActionType() { ActionTypeId = 1, Description = "Start" },
				new ActionType() { ActionTypeId = 2, Description = "Continue" },
				new ActionType() { ActionTypeId = 3, Description = "Hold" },
				new ActionType() { ActionTypeId = 4, Description = "Game Over" });
		}
	}
}
