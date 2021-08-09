using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Please Enter Department Name")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
