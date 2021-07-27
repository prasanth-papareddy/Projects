using Evarsity.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        [EmailAddress]
        [EmailValidator(Validation: "srmuniv.ac.in", ErrorMessage = "Use SRM Email Address")]
        [Remote(action: "ExistingEmailCheck", controller:"Account")]        
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm password does not match")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
