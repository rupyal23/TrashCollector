using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }


    }
}