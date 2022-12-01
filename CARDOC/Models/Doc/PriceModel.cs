using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models.Doc
{
    public class PriceModel
    {
        public decimal Rate { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
