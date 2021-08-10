using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeGetEmployeesViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<string> EmployeeRole { get; set; }
    }
}
