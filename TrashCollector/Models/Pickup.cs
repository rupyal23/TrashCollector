using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }
        public int Zip { get; set; }
        //[ForeignKey("Customer")]
        //[Display(Name = "Customer")]
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public string Day { get; set; }
        public DateTime Time { get; set; }
        [Display(Name = "Number of Pickups")]
        public int NumberOfPickups { get; set; }
        [Display(Name = "PickUp Status")]
        public string PickUpStatus { get; set; }
    }
}