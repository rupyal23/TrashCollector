using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<Pickup> Pickups { get; set; }
        public Employee Employee { get; set; }
    }
}