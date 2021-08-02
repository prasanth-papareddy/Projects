using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.RepositoryModels
{
    public class RoleImplementation : IRoleRepository
    {
        private readonly AppDbContext appDbContext;

        public RoleImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Role> CreateRole(Role role)
        {
            appDbContext.Add(role);
            appDbContext.SaveChanges();
            return appDbContext.Roles.ToList();
        }       

        public IEnumerable<Role> UpdateRole(Role role)
        {            
            var R = appDbContext.Roles.Attach(role);
            R.State = Microsoft.EntityFrameworkCore.EntityState.Modified;            
            appDbContext.SaveChanges();
            return appDbContext.Roles.ToList();
        }

        public IEnumerable<Role>  DeleteRole(int Id)
        {
            Role role = appDbContext.Roles.FirstOrDefault(e=> e.RoleId == Id);
            appDbContext.Roles.Remove(role);
            appDbContext.SaveChanges();
            return appDbContext.Roles.ToList();
        }

        public IEnumerable<Role> GetRoles()
        {
            return appDbContext.Roles.ToList();
        }

        public Role GetRole(int Id)
        {            
            return appDbContext.Roles.FirstOrDefault(e => e.RoleId == Id);
        }
    }
}
