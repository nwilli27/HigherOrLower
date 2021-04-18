using HigherOrLower.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	[Authorize]
	public class ScoresController : Controller
	{
		#region Members

		private IHigherOrLowerDataAccessor data;
		private IHttpContextAccessor httpCtxAccessor;
		private readonly UserManager<User> userManager;

		private GamePlayDL gamePlayDL;

		#endregion

		#region Construction

		public ScoresController(IHigherOrLowerDataAccessor dataAccessor, IHttpContextAccessor httpCtx, UserManager<User> userManager)
		{
			this.data = dataAccessor;
			this.httpCtxAccessor = httpCtx;
			this.userManager = userManager;

			this.gamePlayDL = new GamePlayDL(dataAccessor, userManager);
		}

		#endregion

		#region Actions

		public IActionResult Index() => RedirectToAction("HighScores");

		public async Task<IActionResult> PersonalHighScores()
		{
			var currentUser = await this.userManager.GetUserAsync(User);
			var userHighScoreGames = this.gamePlayDL.GetUserHighScoreGames(currentUser, 3);
			return View(userHighScoreGames);
		}

		public IActionResult GlobalHighScores()
		{
			var users = this.userManager.Users;
			var highestGames = new List<GamePlay>();

			foreach (var user in users)
			{
				if (user.HighScoreGamePlayId > 0)
				{
					highestGames.Add(this.gamePlayDL.GetGamePlay(user.HighScoreGamePlayId));
				}
			}

			highestGames = highestGames.AsQueryable().OrderByDescending(g => g.Score).ToList();

			if (highestGames.Count() >= 3)
			{
				highestGames = highestGames.Take(3).ToList();
			}

			return View(highestGames);
		}

		#endregion
	}
}
