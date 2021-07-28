using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EntityFramework.Models
{
    public class AppDbContext : DbContext
    {
        /* To Configure using dependency Injection */

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

       

        public DbSet<Student> students { get; set; }

        public DbSet<Department> departments { get; set; }

        // To Configure Connection using DbContextOptionsBuilder
      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=PRASANTHREDDY\PRASANTHREDDY;Database=EFCore;User Id=sa;Password=prasanthreddy;");
        }
      */
    }
}
