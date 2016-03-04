using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Footwear
    {
        public int FootwearId { get; set; }
        public string FootwearValue { get; set; }
        public string MadeBy { get; set; }
        public int Size { get; set; }
        public int FootwearTypeId { get; set; }
        public virtual FootwearType FootwearType { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
