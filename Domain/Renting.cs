using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Renting
    {
        public int RentingId { get; set; }
        public string RentValue { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public virtual List<Renting> Rentings { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }


    }
}
