using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class OrderView : Order
    {
        public string Drug { get; set; }
    }
}
