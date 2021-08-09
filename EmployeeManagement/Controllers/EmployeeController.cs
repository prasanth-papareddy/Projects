using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ViewModels;
using EmployeeManagement.RepositoryModels;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        private readonly IDepartmentRepository departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
         
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateViewModel employeeCreateViewModel = new EmployeeCreateViewModel();
            employeeCreateViewModel.Departments = departmentRepository.GetDepartments();
            
            return View(employeeCreateViewModel);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public RedirectToActionResult Create(EmployeeCreateViewModel employeeCreateViewModel)
        {
            if(ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Name = employeeCreateViewModel.Name;
                employee.Email = employeeCreateViewModel.Email;
                employee.Gender = employeeCreateViewModel.Gender.Value;
                employee.UserName = employeeCreateViewModel.UserName;
                employee.Created = DateTime.Now;
                employee.Updated = DateTime.Now;
                employee.DepartmentId = employeeCreateViewModel.Department;
     
               Employee createdemployee =  employeeRepository.CreateEmployee(employee);

               return RedirectToAction("GetEmployees", createdemployee);
            }

            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public IActionResult Update(string Id)
        {
            Employee employee = employeeRepository.GetEmployeebyId(Id);
            UpdateEmployeeViewModel updateEmployeeViewModel = new UpdateEmployeeViewModel();
            updateEmployeeViewModel.Id = employee.Id;
            updateEmployeeViewModel.Name = employee.Name;
            updateEmployeeViewModel.EmailId = employee.Email;
            updateEmployeeViewModel.Gender = employee.Gender;
            updateEmployeeViewModel.DepartmentId = employee.DepartmentId;
            updateEmployeeViewModel.Departments = departmentRepository.GetDepartments();
      

            return View(updateEmployeeViewModel);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public RedirectToActionResult Update(UpdateEmployeeViewModel updateEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Id = updateEmployeeViewModel.Id;
                employee.Name = updateEmployeeViewModel.Name;
                employee.Email = updateEmployeeViewModel.EmailId;
                employee.Gender = updateEmployeeViewModel.Gender.Value;
                employee.Created = updateEmployeeViewModel.Created;
                employee.Updated = DateTime.Now;
                employee.DepartmentId = updateEmployeeViewModel.DepartmentId;
      
                Employee UpdatedEmployee = employeeRepository.UpdateEmployee(employee);
                
            }
            return RedirectToAction("GetEmployees");
        }
        
        public IActionResult GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeRepository.GetAllEmployees();
            return View(employees);

        }
        [Authorize(Roles ="Employee,Admin,Manager")]
        public IActionResult GetEmployee(string Id)
        {
            Employee employee = new Employee();
            employee = employeeRepository.GetEmployeebyId(Id);
            return View(employee);

        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public RedirectToActionResult Delete(string Id)
        {
            employeeRepository.RemoveEmployee(Id);
            return RedirectToAction("GetEmployees");
        }

       

    }
}
