using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class AdministrationUpdateRoleViewModel
    {
        public AdministrationUpdateRoleViewModel()
        {
            Users = new List<RoleUsers>();
        }
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
        public List<RoleUsers> Users { get; set; }



    }

    public class RoleUsers
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }

}
