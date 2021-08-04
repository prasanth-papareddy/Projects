using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.RepositoryModels;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
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
            return View(project);
        }


        [HttpPost]
        public RedirectToActionResult Update(Project Project)
        {
            if (ModelState.IsValid)
            {

                projectRepository.UpdateProject(Project);
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
    }
}
