using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }
}
