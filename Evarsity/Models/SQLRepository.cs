using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.Models
{
    public class SQLRepository : IStudentRepository
    {
        private AppDbContext context;

        public SQLRepository (AppDbContext context)
        {
            this.context = context;
        }        

        StudentDetails IStudentRepository.Create(StudentDetails studentDetails)
        {
            context.students.Add(studentDetails);
            context.SaveChanges();
            return studentDetails;

        }

        StudentDetails IStudentRepository.Delete(StudentDetails SID)
        {
            StudentDetails student = context.students.Find(SID.StudentId);
            if(student != null)
            {
                context.students.Remove(student);
                context.SaveChanges();
            }            
            return student;
        }

        IEnumerable<StudentDetails> IStudentRepository.GetStudentDetails()
        {
            return context.students;
        }

        public StudentDetails Update(StudentDetails studentDetails)
        {
            var student  = context.students.Attach(studentDetails);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentDetails;
        }

        public StudentDetails GetStudent(int Id)
        {
            StudentDetails sd = context.students.FirstOrDefault(e => e.StudentId == Id);
            return sd;
        }
    }
}