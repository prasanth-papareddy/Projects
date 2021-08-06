using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Role role)
        {

            if (ModelState.IsValid)
            {
                IEnumerable<Role> roles = roleRepository.CreateRole(role);
                return RedirectToAction("GetRoles", roles);
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Update(int RoleId)
        {
           Role role =  roleRepository.GetRole(RoleId);
           return View(role);
        }

        [HttpPost]
        public RedirectToActionResult Update(Role role)
        {
            if (ModelState.IsValid)
            {

                roleRepository.UpdateRole(role);
                return RedirectToAction("GetRoles");
            }
            return RedirectToAction("Update");
        }


        public RedirectToActionResult Delete(int RoleId)
        {
            roleRepository.DeleteRole(RoleId);
            return RedirectToAction("GetRoles");
        }

        public IActionResult GetRoles()
        {
            IEnumerable<Role> roles = roleRepository.GetRoles();
            return View(roles);
        }

    }
}
