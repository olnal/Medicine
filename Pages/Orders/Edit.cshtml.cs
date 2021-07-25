using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly OrderList _orderlist;
        private readonly DrugList _druglist;

        public EditModel(OrderList orderlist, DrugList druglist)
        {
            _orderlist = orderlist;
            _druglist = druglist;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var DBDrug = _druglist.Get(Order.Drug.Name);

            if (DBDrug == null)
            {
                var newdrug = new Drug
                {
                    Name = Order.Drug.Name,
                    Type = new DrugType
                    {
                        Type = "Невідомий"
                    },
                    Price = 0,
                    Count = 0
                };
                _druglist.Add(newdrug);
            };
            var editOrder = new Order
            {
                Id = Order.Id,
                Drug = DBDrug,
                Amount = Order.Amount
            };
            

            try
            {
                _orderlist.Edit(editOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(editOrder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _orderlist.Get(id) != null;
        }
    }
}
