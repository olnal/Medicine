using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly OrderList _orderlist;
        public IndexModel(OrderList orderlist)
        {
            _orderlist = orderlist;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = _orderlist.GetAll();
        }
    }
}
