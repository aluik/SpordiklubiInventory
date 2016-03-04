using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FootwearType
    {
        public int FootwearTypeId { get; set; }
        public string FootwearTypeValue { get; set; }
        public virtual List<FootwearType> FootwearTypes { get; set; }
    }
}
