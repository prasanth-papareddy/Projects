using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Please select Gender")]
        public Gender? Gender { get; set; }
        
        public IEnumerable<Department> Departments { get; set; }

        public int Department { get; set; }
    }
}
