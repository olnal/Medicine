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
    public class DeleteModel : PageModel
    {
        
        private readonly OrderList _orderlist;
        public DeleteModel(OrderList orderlist)
        {
            
            _orderlist = orderlist;
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = _orderlist.Get(id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = _orderlist.Get(id);

            if (Order != null)
            {
                _orderlist.Delete(Order.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
