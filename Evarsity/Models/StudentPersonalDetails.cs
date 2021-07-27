using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Evarsity.Models
{
    public class StudentPersonalDetails
    {
            public int Id { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string HomeTown { get; set; }
            public string PrimaryEducation { get; set; }
            public string SecondaryEducation { get; set; }
            public int TenthMarks { get; set; }
            public int InterMarks { get; set; }
            public string DateOfBirth { get; set; }
            public string PermanentAddress { get; set; }
    }
}
