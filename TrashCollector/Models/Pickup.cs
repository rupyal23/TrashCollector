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

        [Required]
        [Display(Name = "Pick-Up Date")]
        public DateTime? PickupDate { get; set; }

        [Display(Name = "Pick-Up Day")]
        public string PickupDay { get; set; }

        [Display(Name = "Second Pick-Up Date")]
        public DateTime? SecondPickupDate { get; set; }

        [Display(Name = "Second Pick-Up Day")]
        public string SecondPickupDay { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}