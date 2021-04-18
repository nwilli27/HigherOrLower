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
	public class HigherOrLowerContext : IdentityDbContext<User>
	{

		public HigherOrLowerContext(DbContextOptions options) : base(options) { }

		public DbSet<PlayingCard> PlayingCards { get; set; }
		public DbSet<GamePlay> GamePlays { get; set; }
		public DbSet<Turn> Turns { get; set; }
		public DbSet<GamePlayTurn> GamePlayTurns { get; set; }
		public DbSet<ActionType> ActionTypes { get; set; }
		public DbSet<GuessType> GuessTypes { get; set; }

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
