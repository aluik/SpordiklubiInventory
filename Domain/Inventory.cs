using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
       //USER SIIA????
        public int InventoryTypeId { get; set; }
        public virtual InventoryType InventoryType { get; set; }
    }
}
