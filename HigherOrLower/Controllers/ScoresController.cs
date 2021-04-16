﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	public class ScoresController : Controller
	{
		public IActionResult Index() => RedirectToAction("HighScores");

		public IActionResult HighScores()
		{
			return View();
		}
	}
}