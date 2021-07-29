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
        
        public IActionResult Create()
        {
            EmployeeCreateViewModel employee = new  EmployeeCreateViewModel();            
            return View(employee);
        }



    }
}
