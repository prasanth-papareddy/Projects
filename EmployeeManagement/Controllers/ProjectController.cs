using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.RepositoryModels;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;

        private readonly IEmployeeRepository employeeRepository;
        public ProjectController(IProjectRepository projectRepository , IEmployeeRepository employeeRepository)
        {
            this.projectRepository = projectRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                projectRepository.CreateProject(project);
                return RedirectToAction("GetProjects","Project");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {

            Project project = projectRepository.GetProject(Id);
            ProjectUpdateViewModel projectUpdateViewModel = new ProjectUpdateViewModel();
            projectUpdateViewModel.Id = project.Id;
            projectUpdateViewModel.Name = project.Name;
            projectUpdateViewModel.Domain = project.Domain;
            projectUpdateViewModel.Budget = project.Budget;
            projectUpdateViewModel.TentativeStartDate = project.TentativeStartDate;
            projectUpdateViewModel.TentativeEndDate = project.TentativeEndDate;
            projectUpdateViewModel.ActualStartDate = project.ActualStartDate;
            projectUpdateViewModel.ActualEndDate = project.ActualEndDate;
            return View(projectUpdateViewModel);
        }


        [HttpPost]
        public RedirectToActionResult Update(ProjectUpdateViewModel projectUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project();
                project.Id = projectUpdateViewModel.Id;
                project.Name = projectUpdateViewModel.Name;
                project.Domain = projectUpdateViewModel.Domain;
                project.Budget = projectUpdateViewModel.Budget;
                project.TentativeStartDate = projectUpdateViewModel.TentativeStartDate;
                project.TentativeEndDate = projectUpdateViewModel.TentativeEndDate;
                project.ActualStartDate = projectUpdateViewModel.ActualStartDate;
                project.ActualEndDate= projectUpdateViewModel.ActualEndDate;

                projectRepository.UpdateProject(project);
                return RedirectToAction("GetProjects");
            }
            return RedirectToAction("Update");
        }


        public RedirectToActionResult Delete(int Id)
        {
            projectRepository.DeleteProject(Id);
            return RedirectToAction("GetProjects");
        }

        public IActionResult GetProjects()
        {
            IEnumerable<Project> Projects = projectRepository.GetProjects();
            return View(Projects);
        }

        public IActionResult GetProject(int Id)
        {
                     
            ProjectGetProjectViewModel projectGetProjectViewModel = new ProjectGetProjectViewModel();
            projectGetProjectViewModel.Project = projectRepository.GetProject(Id);
            projectGetProjectViewModel.ProjectEmployees = projectRepository.GetEmployees(Id);
            return View(projectGetProjectViewModel);
        }


        [HttpGet]
        public IActionResult AddEmployees(int Id)
        {
            ProjectAddEmployeesViewModel projectAddEmployeesViewModel = new ProjectAddEmployeesViewModel();
            projectAddEmployeesViewModel.ProjectId = Id;
            projectAddEmployeesViewModel.Employees = employeeRepository.GetAllEmployees();
            return View(projectAddEmployeesViewModel);
        }        

    }
}
