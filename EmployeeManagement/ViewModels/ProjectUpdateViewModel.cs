using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ProjectUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Project Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Project Domain")]

        public string Domain { get; set; }

        [Required(ErrorMessage = "Please Enter Project Budget")]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Please Select Tentative Start Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Tentative Start Date")]
        public DateTime TentativeStartDate { get; set; }

        [Required(ErrorMessage = "Please Select Tentative End Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Tentative End Date")]
        public DateTime TentativeEndDate { get; set; }

       
        public DateTime ActualStartDate { get; set; }

     
        public DateTime ActualEndDate { get; set; }
    }
}
