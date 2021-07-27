using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Evarsity.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetails>().HasData(
                new StudentDetails
                {
                    StudentId = 555,
                    StudentDepartment = Department.ComputerScience,
                    StudentEmail = "Prasanth@gmail.com",
                    StudentName = "Prasanth",
                    StudentYear = null
                },
                new StudentDetails
                {
                    StudentId = 666,
                    StudentDepartment = Department.ComputerScience,
                    StudentEmail = "Prasanth@gmail.com",
                    StudentName = "Prasanth",
                    StudentYear = null
                }
            );
        }
    }
}
