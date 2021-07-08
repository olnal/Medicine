using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class BuyView : Buy
    {
        public new string Drug { get; set; }
        BuyView()
        {
            Date=DateTime.Now;
        }
    }
}
