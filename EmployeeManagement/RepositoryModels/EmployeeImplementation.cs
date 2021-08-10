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

        private readonly RoleManager<IdentityRole> roleManager;
        public EmployeeImplementation(AppDbContext appDbContext, RoleManager<IdentityRole> roleManager)
        {
            this.appDbContext = appDbContext;
            this.roleManager = roleManager;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            
            var list = (from user in appDbContext.Employees
                                join userRoles in appDbContext.UserRoles on user.Id equals userRoles.UserId
                                join role in appDbContext.Roles on userRoles.RoleId equals role.Id
                                join Department in appDbContext.Departments on user.DepartmentId equals Department.DepartmentId
                                select new {Name = user.Name, UserId = user.Id, UserName = user.UserName, RoleId = role.Id, RoleName = role.Name , Email =user.Email ,Department = Department.DepartmentName ,Gender = user.Gender, })
                        .ToList();
            foreach(var emp in list)
            {
                Employee employee = new Employee()
                {
                    Name = emp.Name,
                    UserName = emp.UserName,
                    Id = emp.UserId,
                    Department = new Department { DepartmentName = emp.Department },
                    Gender = emp.Gender,
                    RoleName = emp.RoleName
                };

                employees.Add(employee);
            }

            return employees;

        }

        public Employee CreateEmployee(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return employee;
        }

        public string GetRoleName(string Id)
        {
            string RoleName = (from user in appDbContext.Employees
                            join userRoles in appDbContext.UserRoles on user.Id equals userRoles.UserId
                            join roles in appDbContext.Roles on userRoles.RoleId equals roles.Id
                            select roles.Name).FirstOrDefault();
            
            return RoleName;
        }

        Employee IEmployeeRepository.GetEmployeebyId(string Id)
        {
            Employee employee  = appDbContext.Employees.Include(x => x.Department)
                .FirstOrDefault(e => e.Id == Id);
            employee.RoleName = GetRoleName(employee.Id);
            return employee;
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
