using CruiseCMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruiseCMSDemo.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Administrator Admin { get; set; }
        public IEnumerable<Personnel> Personnel { get; set; }
    }
}
