using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evarsity.Models;
using Evarsity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evarsity.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly SignInManager<CustomIdentityUser> signInManager;
        public AccountController(UserManager<CustomIdentityUser> userManager , SignInManager<CustomIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateAccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new CustomIdentityUser { UserName = model.Email, Email = model.Email , City = model.City};

                var Result  = await userManager.CreateAsync(user, model.Password);

                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(user,isPersistent : false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var err in Result.Errors)
                    { 
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginAccountViewModel model , string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (Result.Succeeded )
                {

                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else { 
                    return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty , "Invalid Login Attempt");
            }
            return View(model);
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> ExistingEmailCheck(string Email)
        {
            
            var UserExist  = await userManager.FindByEmailAsync(Email);

            if(UserExist == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"EmailId {Email} already exists.. Please use other Email.");
            }
        }

    }
}
