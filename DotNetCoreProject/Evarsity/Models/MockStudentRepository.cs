using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.Models
{

    public class MockStudentRepository : IStudentRepository
    {
        private List<StudentDetails> _studentdetails;

        private List<StudentPersonalDetails> _studentpersonaldetails;
        public MockStudentRepository()
        {

            _studentdetails = new List<StudentDetails>()
            {
                new StudentDetails(){StudentId = 1,
                     StudentName = "Prasanth Reddy",
                     StudentEmail = "prashant.rdy555@Yahoo.com",
                     StudentDepartment = Department.CivilEngineering,
                     StudentYear = "Third Year"},

                new StudentDetails(){StudentId = 2,
                     StudentName = "Naveen Reddy",
                     StudentEmail = "npn.naveen12.com",
                     StudentDepartment = Department.AutoMobileEngineering,
                     StudentYear = "Final Year"}
            };

            _studentpersonaldetails = new List<StudentPersonalDetails>()
            {
                new StudentPersonalDetails()
                {
                    Id=1,
                    FatherName = "Penchal Reddy",
                    MotherName="Sirisha",
                    HomeTown="Nellore",
                    PrimaryEducation="VBR Residential School",
                    SecondaryEducation="Sri Gayathri Junior College",
                    TenthMarks= 540,
                    InterMarks= 911,
                    DateOfBirth="21-May-1997",
                    PermanentAddress="H.No-276, RR Colony, Muthukur, Nellore(524344)"
                },

                new StudentPersonalDetails()
                {
                    Id=2,
                    FatherName = "Penchal Reddy",
                    MotherName="Jayamma",
                    HomeTown="Nellore",
                    PrimaryEducation="VBR Residential School",
                    SecondaryEducation="Narayana Junior College",
                    TenthMarks= 540,
                    InterMarks= 900,
                    DateOfBirth="24-November-1993",
                    PermanentAddress="H.No-277, RR Colony, Muthukur, Nellore(524344)"
                }

            };
        }
        public IEnumerable<StudentDetails> GetStudentDetails()
        {            
            return _studentdetails;
        }

        public StudentPersonalDetails GetStudentPersonalDetails(int Id)
        {
            StudentPersonalDetails spd = new StudentPersonalDetails();
            spd = _studentpersonaldetails.FirstOrDefault(e => e.Id == Id);
            return spd;
        }

        public StudentDetails Create(StudentDetails sd)
        {
            sd.StudentId =_studentdetails.Max(e => e.StudentId) + 1;
            _studentdetails.Add(sd);
            return sd;
        }

        public StudentDetails Delete(StudentDetails studentDetails)
        {
            _studentdetails.Remove(studentDetails);
            return studentDetails;
        }

        StudentDetails IStudentRepository.Update(StudentDetails studentDetails)
        {
            throw new NotImplementedException();
        }

        IEnumerable<StudentDetails> IStudentRepository.GetStudentDetails()
        {
            throw new NotImplementedException();
        }

        StudentDetails IStudentRepository.Create(StudentDetails studentDetails)
        {
            throw new NotImplementedException();
        }

        StudentDetails IStudentRepository.Delete(StudentDetails studentDetails)
        {
            throw new NotImplementedException();
        }

        StudentDetails IStudentRepository.GetStudent(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
