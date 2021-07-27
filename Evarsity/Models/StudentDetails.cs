using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.Models
{
    public class StudentDetails
    {
       [Key]
       public int  StudentId { get; set; }

       [Required(ErrorMessage ="Please Enter Name")]       
       public string StudentName { get; set; }

       [Required(ErrorMessage ="Please Enter Email")]
       [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid Email Format")]
       public string StudentEmail { get; set; }    
       public string StudentYear { get; set; }
       public Department StudentDepartment { get; set; }

       public string PhotoPath { get; set; }
    }
}