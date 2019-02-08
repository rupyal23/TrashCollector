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

        public DateTime? PickupDate { get; set; }

        public DayOfWeek? PickupDay { get; set; }

        public int Zip { get; set; }


    }
}