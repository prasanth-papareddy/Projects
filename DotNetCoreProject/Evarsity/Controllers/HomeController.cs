using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Evarsity.Models;
using Evarsity.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Evarsity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _ISR;
        
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IStudentRepository ISR , IHostingEnvironment hostingEnvironment )
        {
            _ISR = ISR;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {           
           IEnumerable<StudentDetails> SD;      
           SD = _ISR.GetStudentDetails();
           return View(SD);      
        }
      
        [HttpGet]
        public  ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
               string UniqueFileName = null;
               if (model.Photo != null && model.Photo.Count > 0)
               {            
                    foreach(IFormFile file in model.Photo)
                    { 
                      UniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                      string FolderPath = Path.Combine(hostingEnvironment.WebRootPath, "Images");

                      string FilePath = Path.Combine(FolderPath, UniqueFileName);

                      file.CopyTo(new FileStream(FilePath,FileMode.Create));
                    }
                }

                StudentDetails student = new StudentDetails()
                {
                    StudentName = model.StudentName,
                    StudentDepartment = model.StudentDepartment,
                    StudentEmail = model.StudentEmail,
                    PhotoPath = UniqueFileName
                };

                _ISR.Create(student);
                return RedirectToAction("details", new { StudentId = student.StudentId});
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            StudentDetails sd = _ISR.GetStudent(Id);

            if(sd == null)
            {
                Response.StatusCode = 404;
                return View("NotFound" , Id);
            }

            HomeEditViewModel homeEditViewModel = new HomeEditViewModel
            {
                Id = sd.StudentId,
                StudentName = sd.StudentName,
                StudentEmail = sd.StudentEmail,
                ExistingPath = sd.PhotoPath,
                StudentDepartment = sd.StudentDepartment                
            };
            return View(homeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel homeEditViewModel)
        {
            if (ModelState.IsValid)
            {
                string UniqueFileName = null;
                foreach (IFormFile model in homeEditViewModel.Photo)
                {
                    UniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;

                    string Folder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    string FilePath = Path.Combine(Folder, UniqueFileName);

                    using (var fs = new FileStream(FilePath, FileMode.Create))
                    {
                        model.CopyTo(fs);
                    }
                }

                StudentDetails std = new StudentDetails
                {
                    StudentId = homeEditViewModel.Id,
                    StudentName = homeEditViewModel.StudentName,
                    StudentEmail = homeEditViewModel.StudentEmail,
                    StudentDepartment = homeEditViewModel.StudentDepartment,
                    PhotoPath = UniqueFileName
                };
                _ISR.Update(std);
                return RedirectToAction("details", new { StudentId = std.StudentId });
            }
            return View(homeEditViewModel);
        }
        public RedirectToActionResult Delete(StudentDetails SID)
        {
            StudentDetails sn = _ISR.Delete(SID);
            return RedirectToAction("Index",sn);
        }


        public RedirectToActionResult Details()
        {
            return RedirectToAction("Index");
        }
    }   
}