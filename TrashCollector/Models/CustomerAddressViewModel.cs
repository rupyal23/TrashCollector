using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerAddressViewModel
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}