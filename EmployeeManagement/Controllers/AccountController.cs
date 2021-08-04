using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> usermanger;

        private readonly SignInManager<IdentityUser> signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.usermanger = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email
                };

                var Result = await usermanger.CreateAsync(User, registerViewModel.Password);

                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("GetEmployees", "Employee");
                }

                foreach (var err in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View(registerViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("GetEmployees", "Employee");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, isPersistent: loginViewModel.Rememberme, false);

                if (Result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("GetEmployees", "Employee");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return View(loginViewModel);
        }
    }
}
