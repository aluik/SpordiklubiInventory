using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }

        public virtual List<User> Users { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }


    }
}
