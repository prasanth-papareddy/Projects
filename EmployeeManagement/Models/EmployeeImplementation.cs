using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeImplementation : IEmployeeRepository
    {

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            return employees;

        }

        Employee IEmployeeRepository.CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployeebyId(int Id)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.RemoveEmployee(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
