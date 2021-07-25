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
        private readonly OrderList _orderlist;
        public CreateModel(DrugList druglist, OrderList orderlist)
        {
            _druglist = druglist;
            _orderlist = orderlist;
        }

        [BindProperty]
        public Order Order { get; set; }
        public IActionResult OnGetAsync()
        {
            Order = _orderlist.Get();
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            Order = _orderlist.Get();
            while (Order!=null)
            {
                if (Order!=null)
                {
                    var drug = _druglist.Get(Order.Drug.Name);
                    drug.Count += Order.Amount;
                    _druglist.Edit(drug);
                    _orderlist.Delete(Order.Id);
                }
                Order = _orderlist.Get();
            } 
            return RedirectToPage("./Index");
        }
    }
}
