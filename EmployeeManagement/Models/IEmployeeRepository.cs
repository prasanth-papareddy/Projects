using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public  interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeebyId(int Id);

        Employee CreateEmployee(Employee employee);

        Employee RemoveEmployee(int Id);

    }
}
