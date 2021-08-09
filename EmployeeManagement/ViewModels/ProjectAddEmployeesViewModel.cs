using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ProjectAddEmployeesViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string EmployeeDepartment { get; set; }
        public bool IsSelected { get; set; }
    }
}
