using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public class EmployeeImplementation : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;           
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = appDbContext.Employees.Include(x => x.Department).ToList();            
            return employees;

        }

        public Employee CreateEmployee(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return employee;
        }

        Employee IEmployeeRepository.GetEmployeebyId(string Id)
        {
            return appDbContext.Employees.Include(x => x.Department)
                .FirstOrDefault(e => e.Id == Id);
        }

        Employee IEmployeeRepository.RemoveEmployee(string Id)
        {
            Employee employee = appDbContext.Employees.FirstOrDefault(e=> e.Id == Id);
            appDbContext.Remove(employee);
            appDbContext.SaveChanges();
            return employee;
        }
        public Employee UpdateEmployee(Employee employee)
        {
            var Modifiedemployee = appDbContext.Employees.Attach(employee);

            Modifiedemployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Modifiedemployee.Property(x => x.Created).IsModified = false;

            appDbContext.SaveChanges();
            return employee;
        }
    }
}
