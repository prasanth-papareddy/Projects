using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> CreateDepartment(Department department);        

        IEnumerable<Department> UpdateDepartment(Department department);

        IEnumerable<Department> DeleteDepartment(int Id);

        IEnumerable<Department> GetDepartments();

        Department GetDepartment(int Id);



    }
}
