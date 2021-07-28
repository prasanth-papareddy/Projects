using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class StudentImplementation : IStudent
    {
        private AppDbContext appDbContext; 

        public StudentImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Student AddStudents(Student student)
        {
            appDbContext.students.Add(student);
            appDbContext.SaveChanges();
            return student;
        }
    }
}
