using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

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
           
            SetGlobalSoftDeleteQueryFilter(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }

        protected void SetGlobalSoftDeleteQueryFilter(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.FindProperty("IsDeleted");
                if (isDeletedProperty != null
                    && isDeletedProperty.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(
                        entityType.ClrType, "p");
                    var prop = Expression.Property(parameter,
                        isDeletedProperty.PropertyInfo);
                    var filter = Expression.Lambda(Expression.Not(prop),
                        parameter);
                    entityType.SetQueryFilter(filter);
                }
            }
        }
        public override int SaveChanges()
        {
            SetSoftDeleteColumns();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetSoftDeleteColumns();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetSoftDeleteColumns()
        {
            var entriesDeleted = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ISoftDelete
                        && e.State == EntityState.Deleted);

            foreach (var entityEntry in entriesDeleted)
            {
                ((ISoftDelete)entityEntry.Entity).IsDeleted = true;                
                entityEntry.State = EntityState.Modified;
            }
        }

    }
}
