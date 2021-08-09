using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace EmployeeManagement.RepositoryModels
{
    public class AppDbContext : IdentityDbContext<Employee>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

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

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "HR"
                }, new Department { 
                    DepartmentId = 2,
                    DepartmentName = "IT"
                }, new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Dev"
                });

            modelBuilder.Entity<Employee>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Employee>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

            modelBuilder.Entity<Department>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Department>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

            modelBuilder.Entity<Project>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Project>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }


    }
}
