using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
