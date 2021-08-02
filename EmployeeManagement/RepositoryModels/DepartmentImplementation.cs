using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public class DepartmentImplementation : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Department> CreateDepartment(Department department)
        {
            appDbContext.Add(department);
            appDbContext.SaveChanges();
            return appDbContext.Departments.ToList();
        }       

        public IEnumerable<Department> UpdateDepartment(Department department)
        {            
            var dept = appDbContext.Departments.Attach(department);
            dept.State = Microsoft.EntityFrameworkCore.EntityState.Modified;            
            appDbContext.SaveChanges();
            return appDbContext.Departments.ToList();
        }

        public IEnumerable<Department>  DeleteDepartment(int Id)
        {
            Department department = appDbContext.Departments.FirstOrDefault(e=> e.DepartmentId == Id);
            appDbContext.Departments.Remove(department);
            appDbContext.SaveChanges();
            return appDbContext.Departments.ToList();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments.ToList();
        }

        public Department GetDepartment(int Id)
        {            
            return appDbContext.Departments.FirstOrDefault(e => e.DepartmentId == Id);
        }
    }
}
