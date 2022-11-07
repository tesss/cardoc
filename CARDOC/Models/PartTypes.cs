using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Models
{
    public enum PartType
    {
        [Description("Інше")]
        Other,
        [Description("Агрегат")]
        Aggregate,
        [Description("Шина")]
        Tire,
        [Description("Батарея")]
        Battery,
        [Description("Обладнання")]
        Equipment,
        [Description("ЗІП")]
        Zip,
    }
}
