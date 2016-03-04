using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InventoryType
    {
        public int InventoryTypeId { get; set; }
        public string InventoryTypeValue { get; set; }
        public virtual List<InventoryType> InventoryTypes { get; set; }
    }
}
