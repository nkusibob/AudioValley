using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AudioValley.Business.Models
{
    public partial class Adress
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int ZipCode { get; set; }
        public int CountryCode { get; set; }
        [Key]

        public int AdressId { get; set; }
        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
