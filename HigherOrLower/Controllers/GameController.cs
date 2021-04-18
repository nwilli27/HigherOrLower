using HigherOrLower.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	/// <summary>
	/// Holds actions for Game views
	/// 
	/// Author: Nolan Williams
	/// Date:	4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	[Authorize]
	public class GameController : Controller
	{

		#region Members

		private IHigherOrLowerDataAccessor data;
		private IHttpContextAccessor httpCtxAccessor;
		private readonly UserManager<User> userManager;

		private GamePlayDL gamePlayDL;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameController"/> class.
		/// </summary>
		/// <param name="dataAccessor">The data accessor.</param>
		/// <param name="httpCtx">The HTTP CTX.</param>
		public GameController(IHigherOrLowerDataAccessor dataAccessor, IHttpContextAccessor httpCtx, UserManager<User> userManager)
		{
			this.data = dataAccessor;
			this.httpCtxAccessor = httpCtx;
			this.userManager = userManager;

			this.gamePlayDL = new GamePlayDL(dataAccessor, userManager);
		}

		#endregion

		#region Actions

		/// <summary>
		/// Redirects to Play action
		/// </summary>
		/// <returns>Redirect to play action</returns>
		public IActionResult Index() => RedirectToAction("Play");

		/// <summary>
		/// Returns the Play view
		/// </summary>
		/// <returns>The Play view</returns>
		public IActionResult Play()
		{
			var viewModel = new GamePlayViewModel()
			{
				GamePlay = this.getUserCurrentGamePlay().Result
			};
			return View(viewModel);
		}

		/// <summary>
		/// Redirects to play action after updating game state for new game
		/// </summary>
		/// <returns>Redirect to play action</returns>
		public async Task<IActionResult> NewGame()
		{
			await this.checkToEndPreviousGame();
			await this.initializeNewGame();
			return RedirectToAction("Play");
		}

		/// <summary>
		/// Redirects to play action after updating game state for lower guess
		/// </summary>
		/// <returns>Redirect to play action</returns>
		public async Task<IActionResult> Lower(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleGuess(gamePlayId, showingCardId, false);
				await this.checkToUpdateUserHighScoreGame();
			}

			return RedirectToAction("Play");
		}

		/// <summary>
		/// Redirects to play action after updating game state for higher guess
		/// </summary>
		/// <returns>Redirect to play action</returns>
		public async Task<IActionResult> Higher(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleGuess(gamePlayId, showingCardId, true);
				await this.checkToUpdateUserHighScoreGame();
			}

			return RedirectToAction("Play");
		}

		/// <summary>
		/// Redirects to play action after updating game state for hold
		/// </summary>
		/// <returns>Redirect to play action</returns>
		public async Task<IActionResult> Hold(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleHold(gamePlayId, showingCardId);
				await this.checkToUpdateUserHighScoreGame();
			}
			return RedirectToAction("Play");
		}

		#endregion

		#region Private Helpers

		private async Task<GamePlay> getUserCurrentGamePlay()
		{
			var currentUser = await this.userManager.GetUserAsync(User);
			var currentGamePlayId = currentUser != null ? currentUser.CurrentGamePlayId : 0;

			return this.gamePlayDL.GetGamePlay(currentGamePlayId);
		}

		private async Task initializeNewGame()
		{
			var currentUser = await this.userManager.GetUserAsync(User);
			var gamePlay = this.gamePlayDL.InitializeNewGamePlayFor(currentUser);

			currentUser.CurrentGamePlayId = gamePlay.GamePlayId;
			await this.userManager.UpdateAsync(currentUser);
		}

		private async Task checkToEndPreviousGame()
		{
			var gamePlay = this.getUserCurrentGamePlay().Result;

			if (gamePlay != null && !gamePlay.IsGameOver)
			{
				this.gamePlayDL.HandleHold(gamePlay.GamePlayId, gamePlay.CurrentTurn.ShowingCardId.Value);
				await this.checkToUpdateUserHighScoreGame();
			}
		}

		private async Task checkToUpdateUserHighScoreGame()
		{
			var user = await this.userManager.GetUserAsync(User);
			var highScoreGames = this.gamePlayDL.GetUserHighScoreGames(user, 1);

			if (highScoreGames.Count > 0)
			{
				user.HighScoreGamePlayId = highScoreGames.First().GamePlayId;
				await this.userManager.UpdateAsync(user);
			}
		}

		#endregion

	}
}
