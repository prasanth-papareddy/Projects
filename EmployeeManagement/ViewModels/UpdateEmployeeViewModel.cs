using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class UpdateEmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        [Required(ErrorMessage = "Please Select Role")]
        public int RoleId { get; set; }        

        public IEnumerable<Role> Roles { get; set; }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
