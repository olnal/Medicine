using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly DrugList _druglist;
        private readonly BuyList _buylist;
        private readonly OrderList _orderlist;
        public CreateModel(BuyList buylist, DrugList druglist, OrderList orderlist)
        {
            _buylist = buylist;
            _druglist = druglist;
            _orderlist = orderlist;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderlist.Add(Order);
            

            return RedirectToPage("./Index");
        }
    }
}
