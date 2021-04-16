using HigherOrLower.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	public class GameController : Controller
	{
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
	}
}
