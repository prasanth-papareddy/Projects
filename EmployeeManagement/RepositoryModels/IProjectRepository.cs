using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();

        IEnumerable<Project> CreateProject(Project project);

        IEnumerable<Project> UpdateProject(Project project);

        IEnumerable<Project> DeleteProject(int Id);

        Project GetProject(int Id);
    }
}
