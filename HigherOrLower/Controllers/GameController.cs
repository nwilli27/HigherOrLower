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
	[Authorize]
	public class GameController : Controller
	{

		#region Members

		private IHigherOrLowerDataAccessor data;
		private IHttpContextAccessor httpCtxAccessor;
		private readonly UserManager<User> userManager;
		private readonly HigherOrLowerContext context;

		private GamePlayDL gamePlayDL;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameController"/> class.
		/// </summary>
		/// <param name="dataAccessor">The data accessor.</param>
		/// <param name="httpCtx">The HTTP CTX.</param>
		public GameController(IHigherOrLowerDataAccessor dataAccessor, IHttpContextAccessor httpCtx, UserManager<User> userManager, HigherOrLowerContext context)
		{
			this.data = dataAccessor;
			this.httpCtxAccessor = httpCtx;
			this.userManager = userManager;
			this.context = context;

			this.gamePlayDL = new GamePlayDL(dataAccessor);
		}

		#endregion

		#region Actions

		public IActionResult Index() => RedirectToAction("Play");

		public IActionResult PlayAsync()
		{
			var viewModel = new GamePlayViewModel()
			{
				GamePlay = this.getUserCurrentGamePlay().Result
			};
			return View(viewModel);
		}

		public async Task<IActionResult> NewGame()
		{
			this.checkToEndPreviousGame();
			await this.initializeNewGame();
			return RedirectToAction("Play");
		}

		public IActionResult Lower(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleGuess(gamePlayId, showingCardId, false);
			}
			return RedirectToAction("Play");
		}

		public IActionResult Higher(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleGuess(gamePlayId, showingCardId, true);
			}
			return RedirectToAction("Play");
		}

		public IActionResult Hold(int gamePlayId, int showingCardId)
		{
			if (!this.getUserCurrentGamePlay().Result.IsGameOver)
			{
				this.gamePlayDL.HandleHold(gamePlayId, showingCardId);
			}
			return RedirectToAction("Play");
		}

		#endregion

		#region Private Helpers

		private async Task<GamePlay> getUserCurrentGamePlay()
		{
			var currentUser = await this.userManager.GetUserAsync(User);
			var currentGamePlayId = currentUser.CurrentGamePlayId;

			return this.gamePlayDL.GetUserCurrentGamePlay(currentGamePlayId);
		}

		private async Task initializeNewGame()
		{
			var currentUser = await this.userManager.GetUserAsync(User);
			var gamePlay = this.gamePlayDL.InitializeNewGamePlayFor(currentUser);

			currentUser.CurrentGamePlayId = gamePlay.GamePlayId;
			await this.userManager.UpdateAsync(currentUser);
		}

		private void checkToEndPreviousGame()
		{
			var gamePlay = this.getUserCurrentGamePlay().Result;

			if (!gamePlay.IsGameOver)
			{
				this.gamePlayDL.HandleHold(gamePlay.GamePlayId, gamePlay.CurrentTurn.ShowingCardId.Value);
			}
		}

		#endregion

	}
}
