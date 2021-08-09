using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class AdministrationUpdateUserViewModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }

    }
}
