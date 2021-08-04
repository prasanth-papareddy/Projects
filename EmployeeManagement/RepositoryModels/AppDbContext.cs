using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.RepositoryModels
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Employee>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<ProjectEmployee>().HasKey(sc => new { sc.EmployeeId , sc.ProjectId});

            //modelBuilder.Entity<Department>().HasData(

            //    new Department
            //    {
            //        DepartmentId =1,
            //        DepartmentName = "HR"
            //    });

        }
    }
}
