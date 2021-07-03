using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class DrugView : Drug
    {
        public new string Type { get; set; }
    }
}
