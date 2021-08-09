using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee : IdentityUser
    {
     
        //public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

     
        [Required(ErrorMessage ="Please select Gender")]        
        public Gender? Gender { get; set; }



        // Department Relation

        [ForeignKey("Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }



        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public IList<ProjectEmployee>  ProjectEmployees { get; set; }
        
    }
}
