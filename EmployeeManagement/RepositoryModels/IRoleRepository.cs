using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.RepositoryModels
{
    public interface IRoleRepository
    {
        IEnumerable<Role> CreateRole(Role role);

        IEnumerable<Role> UpdateRole(Role role);

        IEnumerable<Role> DeleteRole(int Id);

        IEnumerable<Role> GetRoles();

        Role GetRole(int Id);
    }
}
