using AudioValley.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudioValley.ViewModel
{
    public class ContactInfo
    {
        public ContactInfo()
        {
            Adresses = new HashSet<Adress>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

       
        public string Email { get; set; }

        [Key]
        public int ContactId { get; set; }

        public virtual ICollection<Adress> Adresses { get; set; }
    }
}
