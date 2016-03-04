using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }

        [MaxLength(128)]
        public string ContactValue { get; set; }

        public int PersonId { get; set; }
        [Required]
        public virtual Person Person { get; set; }

        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

    }
}
