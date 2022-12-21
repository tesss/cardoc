using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models.Doc
{
    public class AT1Model
    {
        public KeyValuePair<string, int>[] Counts { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
