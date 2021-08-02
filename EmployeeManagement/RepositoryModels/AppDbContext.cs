using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .Property(e => e.Gender)
                .HasConversion<string>();


            //modelBuilder.Entity<Department>().HasData(

            //    new Department
            //    {
            //        DepartmentId =1,
            //        DepartmentName = "HR"
            //    },
                
            //    new Department
            //    {
            //        DepartmentId =2,
            //        DepartmentName = "IT"
            //    },
            //    new Department
            //    {
            //        DepartmentId =3,
            //        DepartmentName = "Dev"
            //    }
            //    );

        }
    }
}
