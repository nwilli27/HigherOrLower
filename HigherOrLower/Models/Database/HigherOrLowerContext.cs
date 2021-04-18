using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
	/// <summary>
	/// Holds functionality for the applications implementation of DbContext
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{HigherOrLower.Models.User}" />
	public class HigherOrLowerContext : IdentityDbContext<User>
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="HigherOrLowerContext"/> class.
		/// </summary>
		/// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext" />.</param>
		public HigherOrLowerContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// Gets or sets the playing cards.
		/// </summary>
		/// <value>
		/// The playing cards.
		/// </value>
		public DbSet<PlayingCard> PlayingCards { get; set; }

		/// <summary>
		/// Gets or sets the game plays.
		/// </summary>
		/// <value>
		/// The game plays.
		/// </value>
		public DbSet<GamePlay> GamePlays { get; set; }

		/// <summary>
		/// Gets or sets the turns.
		/// </summary>
		/// <value>
		/// The turns.
		/// </value>
		public DbSet<Turn> Turns { get; set; }

		/// <summary>
		/// Gets or sets the game play turns.
		/// </summary>
		/// <value>
		/// The game play turns.
		/// </value>
		public DbSet<GamePlayTurn> GamePlayTurns { get; set; }

		/// <summary>
		/// Gets or sets the action types.
		/// </summary>
		/// <value>
		/// The action types.
		/// </value>
		public DbSet<ActionType> ActionTypes { get; set; }

		/// <summary>
		/// Gets or sets the guess types.
		/// </summary>
		/// <value>
		/// The guess types.
		/// </value>
		public DbSet<GuessType> GuessTypes { get; set; }

		/// <summary>
		/// Configures the schema needed for the identity framework.
		/// </summary>
		/// <param name="builder">The builder being used to construct the model for this context.</param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			this.buildKeys(builder);
			this.buildForeignKeys(builder);
			this.buildConstaints(builder);
			this.seedData(builder);
		}

		private void buildKeys(ModelBuilder builder)
		{
			builder.Entity<GamePlayTurn>().HasKey(pt => new { pt.GamePlayId, pt.TurnId });
		}

		private void buildForeignKeys(ModelBuilder builder)
		{
			builder.Entity<GamePlayTurn>().HasOne(pt => pt.GamePlay).WithMany(p => p.Turns).HasForeignKey(pt => pt.GamePlayId);
		}

		private void buildConstaints(ModelBuilder builder)
		{
			builder.Entity<Turn>().HasOne(t => t.ShowingCard).WithMany().OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Turn>().HasOne(t => t.FlippedCard).WithMany().OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Turn>().HasOne(t => t.ActionType).WithMany().HasForeignKey(t => t.ActionTypeId).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Turn>().HasOne(t => t.GuessType).WithMany().HasForeignKey(t => t.GuessTypeId).OnDelete(DeleteBehavior.Restrict);
		}

		private void seedData(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new SeedPlayingCards());
			builder.ApplyConfiguration(new SeedActionTypes());
			builder.ApplyConfiguration(new SeedGuessTypes());
		}

		/// <summary>
		/// Creates the admin user.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		public static async Task CreateAdminUser(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			var username = "admin";
			var password = "password";
			var roleName = "Admin";

			if (await roleManager.FindByNameAsync(username) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}

			if (await userManager.FindByNameAsync(username) == null)
			{
				var user = new User { UserName = username };
				var result = await userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, roleName);
				}
			}
		}
	}
}
