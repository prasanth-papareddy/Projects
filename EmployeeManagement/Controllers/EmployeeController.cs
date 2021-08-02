using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ViewModels;
using EmployeeManagement.RepositoryModels;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        private readonly IDepartmentRepository departmentRepository;

        private readonly IRoleRepository roleRepository;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository , IRoleRepository roleRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.roleRepository = roleRepository;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateViewModel employeeCreateViewModel = new EmployeeCreateViewModel();
            employeeCreateViewModel.Departments = departmentRepository.GetDepartments();
            employeeCreateViewModel.Roles = roleRepository.GetRoles();
            return View(employeeCreateViewModel);
        }

        [HttpPost]
        public RedirectToActionResult Create(EmployeeCreateViewModel employeeCreateViewModel)
        {
            if(ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Name = employeeCreateViewModel.Name;
                employee.EmailId = employeeCreateViewModel.EmailId;
                employee.Gender = employeeCreateViewModel.Gender.Value;
                employee.Created = DateTime.Now;
                employee.Updated = DateTime.Now;
                employee.DepartmentId = employeeCreateViewModel.Department;
                employee.RoleId = employeeCreateViewModel.Role;
               Employee createdemployee =  employeeRepository.CreateEmployee(employee);

               return RedirectToAction("GetEmployees", createdemployee);
            }

            return RedirectToAction("Create");
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Employee employee = employeeRepository.GetEmployeebyId(Id);            
            return View(employee);
        }

        [HttpPost]
        public RedirectToActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Id = emp.Id;
                employee.Name = emp.Name;
                employee.EmailId = emp.EmailId;
                employee.Gender = emp.Gender.Value;
                employee.Created = emp.Created;
                employee.Updated = DateTime.Now;

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

        public IActionResult GetEmployee(int Id)
        {
            Employee employee = new Employee();
            employee = employeeRepository.GetEmployeebyId(Id);
            return View(employee);

        }

        [HttpGet]
        public RedirectToActionResult Delete(int Id)
        {
            employeeRepository.RemoveEmployee(Id);
            return RedirectToAction("GetEmployees");
        }

       

    }
}
