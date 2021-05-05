using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AudioValley.Business.Models
{
    public partial class Contact
    {

        public Contact()
        {
            Adresses = new HashSet<Adress>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public byte[] Password { get; set; }
        [Key]
        public int ContactId { get; set; }

        public virtual ICollection<Adress> Adresses { get; set; }
    }
}
