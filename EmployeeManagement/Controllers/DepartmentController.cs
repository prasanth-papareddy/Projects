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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Department department)
        {

            if (ModelState.IsValid)
            {
                IEnumerable<Department> departments = departmentRepository.CreateDepartment(department);
                return RedirectToAction("GetDepartments", departments);
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Update(int DepartmentId)
        {
           Department department =  departmentRepository.GetDepartment(DepartmentId);
           return View(department);
        }

        [HttpPost]
        public RedirectToActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {

                departmentRepository.UpdateDepartment(department);
                return RedirectToAction("GetDepartments");
            }
            return RedirectToAction("Update");
        }


        public RedirectToActionResult Delete(int DepartmentId)
        {
            departmentRepository.DeleteDepartment(DepartmentId);
            return RedirectToAction("GetDepartments");
        }
        
        public IActionResult GetDepartments()
        {
            IEnumerable<Department> departments = departmentRepository.GetDepartments();
            return View(departments);
        }


    }
}
