using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ProjectEmployee
    {
        [ForeignKey("Employee")]
        public string EmployeeId  { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
        
    }
}
