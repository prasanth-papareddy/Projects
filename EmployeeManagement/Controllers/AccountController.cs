using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagement.RepositoryModels;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> usermanger;

        private readonly SignInManager<Employee> signInManager;

        private readonly IDepartmentRepository departmentRepository;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager , IDepartmentRepository departmentRepository , RoleManager<IdentityRole> roleManager)
        {
            this.usermanger = userManager;
            this.signInManager = signInManager;
            this.departmentRepository = departmentRepository;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.Departments = departmentRepository.GetDepartments();
            return View(registerViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Employee
                {
                    Name = registerViewModel.Name,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UN,
                    Gender = registerViewModel.Gender,
                    DepartmentId = registerViewModel.DepartmentId,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,                    
                };

                var Result = await usermanger.CreateAsync(user, registerViewModel.Password);

              
                if(await roleManager.RoleExistsAsync("Employee"))
                {
                    var role = await roleManager.FindByNameAsync("Employee");
                    IdentityResult RoleUsersResult = await usermanger.AddToRoleAsync(user,role.Name);
                }
                else
                {                    
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = "Employee"
                    };
                    IdentityResult identityResult = await roleManager.CreateAsync(identityRole);
                    if(identityResult.Succeeded)
                    {
                        IdentityResult RoleUsersResult = await usermanger.AddToRoleAsync(user, identityRole.Name);
                    }
                }
                              

                if (Result.Succeeded)
                {
                    if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("GetEmployees", "Employee");
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
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
