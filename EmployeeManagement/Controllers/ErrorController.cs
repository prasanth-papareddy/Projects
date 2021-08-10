using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            switch(StatusCode)
            {
                case 404:
                        ViewBag.ErrorMessage = "Resource Not Found";
                    break;
            }
            return View("Not Found");
        }
    }
}
