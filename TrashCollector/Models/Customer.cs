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
        public string Email { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public double Budget { get; set; }
        [ForeignKey("Pickup")]
        [Display(Name = "Next Pickup")]
        public int NextPickupId { get; set; }
        public Pickup Pickup { get; set; }
        [Display(Name = "Suspend Start Date")]
        public string SuspendStartDate { get; set; }
        [Display(Name = "Suspend End Date")]
        public string SuspendEndDate { get; set; }
        

    }
}