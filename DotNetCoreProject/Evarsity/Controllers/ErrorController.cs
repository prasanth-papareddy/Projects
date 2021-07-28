using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Evarsity.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {            
            return View(statusCode);
        }

        [Route("Error")]
        public IActionResult ExceptionHandling()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Error = "Error Occured in loading the page...";
            logger.LogWarning($"Error Message {ExceptionDetails.Error.Message}. StackTrace : {ExceptionDetails.Error.StackTrace}" );

            return View();
        }


    }
}
