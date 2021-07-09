using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medicine.Data;
using Medicine.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Pages.Buys
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
        public BuyView BuyView { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var addBuy = new Buy
            {
                Id = BuyView.Id,
                Drug = _druglist.Get(BuyView.Drug),
                Amount=BuyView.Amount,
                Date=BuyView.Date
            };
            var add = _druglist.Get(BuyView.Drug);            


             if (add.Count>=addBuy.Amount)
            {
                add.Count = add.Count - addBuy.Amount;
                _druglist.Edit(add);
                _buylist.Add(addBuy);
                var addOrder = new Order
                {
                    Drug = _druglist.Get(BuyView.Drug),
                    Id = _orderlist.Get(_druglist.Get(BuyView.Drug)).Id,
                    Amount = BuyView.Amount
                };
                if (_orderlist.Get(addOrder.Drug)==null)
                {
                    _orderlist.Add(addOrder);
                }
                else
                {
                    addOrder.Amount = addOrder.Amount + _orderlist.Get(_druglist.Get(BuyView.Drug)).Amount;
                    _orderlist.Edit(addOrder);
                }
                
            }
             else
            {
                ViewData["Message"] = "Ці ліки наявні в кількості "+add.Count;
                return Page();
            }
            
            return RedirectToPage("./Index");
        }
        private bool DrugExists(int id)
        {
            return _druglist.Get(id) != null;
        }
    }
}
