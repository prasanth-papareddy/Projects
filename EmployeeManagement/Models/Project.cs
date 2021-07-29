using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }

        public decimal Budget { get; set; }

        public DateTime TentativeStartDate { get; set; }

        public DateTime TentativeEndDate { get; set; }

        public DateTime ActualStartDate { get; set; }

        public DateTime ActualEndDate { get; set; }


    }
}