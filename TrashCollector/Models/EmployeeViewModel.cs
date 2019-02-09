using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Pickup Pickup { get; set; }
    }
}