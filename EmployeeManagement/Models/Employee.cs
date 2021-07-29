using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        
    }
}
