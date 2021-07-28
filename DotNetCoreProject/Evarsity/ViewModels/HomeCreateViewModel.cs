using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Evarsity.Models;
using Microsoft.AspNetCore.Http;

namespace Evarsity.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string StudentEmail { get; set; }
        public string StudentYear { get; set; }
        public Department StudentDepartment { get; set; }       
        public List<IFormFile> Photo { get; set; }

    }
}
