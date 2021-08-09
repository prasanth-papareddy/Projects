using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.RepositoryModels;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;

        private readonly IEmployeeRepository employeeRepository;
        public ProjectController(IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
        {
            this.projectRepository = projectRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                projectRepository.CreateProject(project);
                return RedirectToAction("GetProjects", "Project");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
                project.ActualEndDate = projectUpdateViewModel.ActualEndDate;

                projectRepository.UpdateProject(project);
                return RedirectToAction("GetProjects");
            }
            return RedirectToAction("Update");
        }

        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
        public IActionResult ManageEmployees(int Id)
        {
            ViewBag.ProjectId = Id;
            var model = new List<ProjectAddEmployeesViewModel>();
            var Projectemployees = projectRepository.GetEmployees(Id).Select(x => x.EmployeeId).ToHashSet();
            IEnumerable<Employee> AllEmployees = employeeRepository.GetAllEmployees();
        
            foreach (var allEmployees in AllEmployees)
            {

                var projectAddEmployeesViewModel = new ProjectAddEmployeesViewModel
                {
                    EmployeeId = allEmployees.Id,
                    EmployeeName = allEmployees.Name,
                    EmployeeDepartment = allEmployees.Department.DepartmentName
                };
                if(Projectemployees.Contains(allEmployees.Id))
                {
                    projectAddEmployeesViewModel.IsSelected = true;
                }                
                model.Add(projectAddEmployeesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult ManageEmployees(List<ProjectAddEmployeesViewModel> model, int ProjectId)
        {
           
            for (int i = 0; i < model.Count; i++)
            {
                if (model[i].IsSelected)
                {
                   
                    ProjectEmployee projectEmployee = new ProjectEmployee();
                    projectEmployee.EmployeeId = model[i].EmployeeId;
                    projectEmployee.ProjectId = Convert.ToInt32(ProjectId);
                    
                    projectRepository.AddEmployee(projectEmployee);
                }
                else
                {
                    ProjectEmployee projectEmployee = new ProjectEmployee();
                    projectEmployee.EmployeeId = model[i].EmployeeId;
                    projectEmployee.ProjectId = Convert.ToInt32(ProjectId);
                    projectRepository.RemoveEmployee(projectEmployee);
                }
            }
            return RedirectToAction("GetProject" , "Project", new { Id = ProjectId});
        }



    }
}