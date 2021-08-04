using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public class ProjectImplementation : IProjectRepository
    {
        private readonly AppDbContext appDbContext;

        public ProjectImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Project> CreateProject(Project project)
        {
            appDbContext.Projects.Add(project);
            appDbContext.SaveChanges();
            return appDbContext.Projects.ToList();
        }

        public IEnumerable<Project> DeleteProject(int Id)
        {
            Project project = appDbContext.Projects.FirstOrDefault(e => e.Id == Id);
            appDbContext.Projects.Remove(project);
            appDbContext.SaveChanges();
            return appDbContext.Projects.ToList();
        }

        public IEnumerable<Project> GetProjects()
        {
            return appDbContext.Projects.ToList();
        }

        public IEnumerable<Project> UpdateProject(Project project)
        {
            var Project = appDbContext.Projects.Attach(project);
            Project.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return appDbContext.Projects.ToList();
        }

        public Project GetProject(int Id)
        {            
            return appDbContext.Projects.FirstOrDefault(e => e.Id == Id);
        }        
        public IEnumerable<ProjectEmployee> GetEmployees(int Id)
        {
            return appDbContext.ProjectEmployees.Include(e => e.Employee).
                Include(e => e.Project).
                Where(e => e.ProjectId == Id).ToList();                
        }

        public void AddEmployee(ProjectEmployee projectEmployee)
        {
            appDbContext.ProjectEmployees.Add(projectEmployee);
            appDbContext.SaveChanges();            
        }
    }
}
