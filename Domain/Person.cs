using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public virtual List<Contact> Contacts { get; set; }


        [NotMapped]
        public string FirstLastName => (FirstName + " " + LastName).Trim();
        [NotMapped]
        public string LastFirstName => (LastName + " " + FirstName).Trim();
    }
}
