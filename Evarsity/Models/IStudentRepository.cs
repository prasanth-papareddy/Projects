using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evarsity.Controllers;

namespace Evarsity.Models
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDetails> GetStudentDetails();

        public StudentDetails Create(StudentDetails studentDetails);

        public StudentDetails Delete(StudentDetails studentDetails);

        public StudentDetails Update(StudentDetails studentDetails);

        public StudentDetails GetStudent(int Id);
    }
}
