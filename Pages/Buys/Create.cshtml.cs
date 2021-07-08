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
        public CreateModel(BuyList buylist, DrugList druglist)
        {
            _buylist = buylist;
            _druglist = druglist;
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

            _buylist.Add(addBuy);
            /*try
            {
                _buylist.Add(addBuy);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(addBuy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */
            return RedirectToPage("./Index");
        }
        private bool DrugExists(int id)
        {
            return _druglist.Get(id) != null;
        }
    }
}
