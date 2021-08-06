using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AdminstrationCreateRoleViewModel adminstrationCreateRoleViewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = adminstrationCreateRoleViewModel.Name
                };

                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);

                if(identityResult.Succeeded)
                {
                    return RedirectToAction("GetEmployees" , "Employee");
                }

                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(adminstrationCreateRoleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(string Id)
        {
            IdentityRole identityRole = await roleManager.FindByIdAsync(Id);

            AdminstrationUpdateRoleViewModel adminstrationUpdateRoleViewModel = new AdminstrationUpdateRoleViewModel
            {
                Id = identityRole.Id,
                Name = identityRole.Name
            };

            return View(adminstrationUpdateRoleViewModel);
        }
    }
}
