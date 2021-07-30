using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        private readonly IDepartmentRepository departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel employeeCreateViewModel)
        {
            if(ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Name = employeeCreateViewModel.Name;
                employee.EmailId = employeeCreateViewModel.EmailId;
                employee.Gender = employeeCreateViewModel.Gender.Value;
                employee.Created = DateTime.Now;
                employee.Updated = DateTime.Now;

               Employee createdemployee =  employeeRepository.CreateEmployee(employee);

               return View("View" , createdemployee);
            }

            return View();
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
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeRepository.GetAllEmployees();
            return View(employees);

        }

        public IActionResult Details(int Id)
        {
            Employee employee = new Employee();
            employee = employeeRepository.GetEmployeebyId(Id);
            return View(employee);

        }

        [HttpGet]
        public RedirectToActionResult Delete(int Id)
        {
            employeeRepository.RemoveEmployee(Id);
            return RedirectToAction("List");
        }

       

    }
}
