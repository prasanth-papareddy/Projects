using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Please select Gender")]        
        public Gender? Gender { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        
    }
}
