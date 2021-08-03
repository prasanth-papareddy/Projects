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
            return View();
        }
    }
}
