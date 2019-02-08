using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Zip { get; set; }

        [ForeignKey("ApplicationUser")]
        public string AppicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Pickup")]
        [Display(Name = "Pickup")]
        public int? PickupId { get; set; }
        public Pickup Pickup { get; set; }

        public List<Pickup>Pickups { get; set; }
    }
}