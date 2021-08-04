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
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        public DateTime TentativeStartDate { get; set; }

        public DateTime TentativeEndDate { get; set; }

        public DateTime ActualStartDate { get; set; }

        public DateTime ActualEndDate { get; set; }


    }
}