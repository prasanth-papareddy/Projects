using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudent _student;

        public HomeController(IStudent _student)
        {
            this._student = _student;
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            Student std  = _student.AddStudents(student);            
            return View("Index", std);
        }

        public void Index()
        {

        }


    }
}
