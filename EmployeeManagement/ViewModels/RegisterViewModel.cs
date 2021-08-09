using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Provide Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm password do not match.")]
        public string  ConfirmPassword { get; set; }
    }
}
