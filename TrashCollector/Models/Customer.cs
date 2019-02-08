using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Address")]
        [Display(Name ="Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Pickup")]
        [Display(Name ="Pickup")]
        public int? PickupId { get; set; }
        public Pickup Pickup { get; set; }


        [ForeignKey ("ApplicationUser")]
        public string AppicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public double Balance { get; set; }

        public double Budget { get; set; }

        [Display(Name = "Next Pickup")]
        public DateTime? PickUpDay { get; set; }

        [Display(Name = "Extra Pickup")]
        public DateTime? SecondPickUpDay { get; set; }

        public bool ExtraPickupRequest { get; set; }

        [Display(Name = "Total Pickups")]
        public int TotalPickups { get; set; }

        [Display(Name = "Suspend Start Date")]
        public DateTime? SuspendStartDate { get; set; }

        [Display(Name = "Suspend End Date")]
        public DateTime? SuspendEndDate { get; set; }
        

    }
}