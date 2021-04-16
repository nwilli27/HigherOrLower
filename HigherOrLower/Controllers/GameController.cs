using HigherOrLower.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	[Authorize]
	public class GameController : Controller
	{

		#region Members

		private IHigherOrLowerDataAccessor data;
		private IHttpContextAccessor httpCtxAccessor;

		#endregion

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameController"/> class.
		/// </summary>
		/// <param name="dataAccessor">The data accessor.</param>
		/// <param name="httpCtx">The HTTP CTX.</param>
		public GameController(IHigherOrLowerDataAccessor dataAccessor, IHttpContextAccessor httpCtx)
		{
			this.data = dataAccessor;
			this.httpCtxAccessor = httpCtx;
		}

		#endregion

		#region Actions

		public IActionResult Index() => RedirectToAction("Play");

		public IActionResult Play()
		{
			var viewModel = new GamePlayViewModel()
			{
				GamePlay = new GamePlay()
			};
			return View(viewModel);
		}

		public IActionResult NewGame()
		{
			return RedirectToAction("Play");
		}

		public IActionResult Lower()
		{
			return RedirectToAction("Play");
		}

		public IActionResult Higher()
		{
			return RedirectToAction("Play");
		}

		public IActionResult Hold()
		{
			return RedirectToAction("Play");
		}

		#endregion

	}
}
