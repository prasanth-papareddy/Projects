using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class DepartmentImplementation : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments.ToList();
        }
    }
}
