using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evarsity.ViewModels
{
    public class HomeEditViewModel : HomeCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPath { get; set; }
    }
}
