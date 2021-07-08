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
        [BindProperty]
        public BuyView BuyView { get; set; }

        public IActionResult OnGet()
        {
            
            return Page();
        }        

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
            var x = _druglist.Get(BuyView.Drug);
            
             if (x.Count>=addBuy.Amount)
            {
                x.Count = x.Count - addBuy.Amount;
                _druglist.Edit(x);
                _buylist.Add(addBuy);
            }
             else
            {
                ViewData["Message"] = "Ці ліки наявні в кількості "+x.Count;
                return Page();
            }
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
            }*/
            
            return RedirectToPage("./Index");
        }
        private bool DrugExists(int id)
        {
            return _druglist.Get(id) != null;
        }
    }
}
