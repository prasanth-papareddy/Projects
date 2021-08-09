using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public  interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeebyId(string Id);

        Employee CreateEmployee(Employee employee);

        Employee RemoveEmployee(string Id);

        Employee UpdateEmployee(Employee employee);

    }
}
