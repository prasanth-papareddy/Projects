using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evarsity.Models;

namespace Evarsity.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<StudentDetails> studentdetails { get; set; }

        public List<StudentPersonalDetails> studentpersonaldetails { get; set; }

        public string pagetitle { get; set; }

        public string header { get; set; }
    }
}
