using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.RepositoryModels;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<Employee> userManager;

        private readonly IDepartmentRepository departmentRepository;
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<Employee> userManager, IDepartmentRepository departmentRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AdministrationCreateRoleViewModel administrationCreateRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = administrationCreateRoleViewModel.Name
                };

                IdentityResult identityResult = await roleManager.CreateAsync(identityRole);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("GetEmployees", "Employee");
                }

                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(administrationCreateRoleViewModel);
        }

        public IActionResult GetRoles()
        {
            var model = roleManager.Roles;
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateRole(string Id)
        {
            IdentityRole identityRole = await roleManager.FindByIdAsync(Id);

            AdministrationUpdateRoleViewModel model = new AdministrationUpdateRoleViewModel
            {
                Id = identityRole.Id,
                Name = identityRole.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, model.Name))
                {
                    model.Users.Add(new RoleUsers { Name = user.UserName, UserId = user.Id, IsSelected = true });
                }
                else
                {
                    model.Users.Add(new RoleUsers { Name = user.UserName, UserId = user.Id, IsSelected = false });
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(AdministrationUpdateRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.Name;


            for (int i = 0; i < model.Users.Count; i++)
            {

                var user = await userManager.FindByIdAsync(model.Users[i].UserId);

                IdentityResult RoleUsersResult = null;

                if (model.Users[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    RoleUsersResult = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model.Users[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    RoleUsersResult = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (RoleUsersResult.Succeeded)
                {
                    if (i < (model.Users.Count - 1))
                        continue;
                    else
                        return RedirectToAction("UpdateRole", new { Id = model.Id });
                }
            }

            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("GetRoles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);

                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("GetRoles");
            }
            catch (DbUpdateException Ex)
            {
                return ViewBag.ErrorMessage = "Cannot delete role as users exists in present role";

            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var model = new AdministrationUpdateUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
                Gender = user.Gender,
                DepartmentId = user.DepartmentId,
                Departments = departmentRepository.GetDepartments()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(AdministrationUpdateUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Name = model.Name;
            user.DepartmentId = model.DepartmentId;
            user.Gender = model.Gender;
            user.Updated = DateTime.Now;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("GetEmployees", "Employee");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("GetEmployees", "Employee");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("GetUsers");

        }

        [HttpGet]

        public IActionResult GetUsers()
        {
            var model = userManager.Users;
            return View(model);
        }

    }
}
