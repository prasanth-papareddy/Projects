using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Project
    {     
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Project Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Project Domain")]

        public string Domain { get; set; }

        [Required(ErrorMessage = "Please Enter Project Budget")]
        [DataType(DataType.Currency,ErrorMessage = "Please Enter Project Budget")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage ="Please Select Tentative Start Date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Start Date")]
        [Display(Name="Tentative Start Date")]
        public DateTime TentativeStartDate { get; set; }

        [Required(ErrorMessage = "Please Select Tentative End Date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid End Date")]
        [Display(Name = "Tentative End Date")]
        public DateTime TentativeEndDate { get; set; }
        
        public DateTime ActualStartDate { get; set; }

        public DateTime ActualEndDate { get; set; }

        public IList<ProjectEmployee> ProjectEmployees { get; set; }

        public bool IsDeleted { get; set; }
    }
}