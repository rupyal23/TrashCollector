using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Customer")]
        //[Display(Name = "Customer Name")]
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        //[ForeignKey("Pickup")]
        //[Display(Name = "Next Pickup")]
        //public int NextPickupId { get; set; }
        //public Pickup Pickup { get; set; }
        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        
    }
}