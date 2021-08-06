﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class AdminstrationCreateRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name="Role Name")]
        public string Name { get; set; }

    }
}