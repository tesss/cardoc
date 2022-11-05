using CARDOC.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models
{
    public class Part
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public string Number { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        public int Index { get; set; }
        public PartType PartType 
        {
            get
            {
                return Type.GetValueFromDescription<PartType>();
            }
            set
            {
                Type = value.GetDescription();
            }
        }
    }
}
