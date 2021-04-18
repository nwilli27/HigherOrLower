using HigherOrLower.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Controllers
{
	/// <summary>
	/// Holds action for Action views
    /// 
    /// Author: Nolan Williams
    /// Date:   4/18/2021
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class AccountController : Controller
	{
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountController"/> class.
		/// </summary>
		/// <param name="userMngr">The user MNGR.</param>
		/// <param name="signInMngr">The sign in MNGR.</param>
		public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

		/// <summary>
		/// Returns register view
		/// </summary>
		/// <returns>Returns register view</returns>
		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		/// <summary>
		/// Register post action, creates user from form data
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>Redirect to Index action in Game controller</returns>
		[HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Game");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

		/// <summary>
		/// Signs out User and redirects to Index action in Game controller
		/// </summary>
		/// <returns>Redirect to Index action in Game controller</returns>
		[HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Game");
        }

		/// <summary>
		/// Returns the Login view
		/// </summary>
		/// <param name="returnURL">The return URL.</param>
		/// <returns>The login view</returns>
		[HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        /// <summary>
        /// Login post action, handles login and redirects to Index action in Game controller
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>redirects to Index action in Game controller</returns>
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Game");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        /// <summary>
        /// Returns access denied view
        /// </summary>
        /// <returns>Returns access denied view</returns>
        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}

