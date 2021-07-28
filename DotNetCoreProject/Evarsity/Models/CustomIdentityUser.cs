using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string City { get; set; } 
    }
}
