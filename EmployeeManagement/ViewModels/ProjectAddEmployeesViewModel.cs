using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ProjectAddEmployeesViewModel
    {
        public int ProjectId { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
