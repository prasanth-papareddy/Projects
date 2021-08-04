using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ProjectGetProjectViewModel
    {
        public Project Project { get; set; } 
        public IEnumerable<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
