using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Buys
{
    public class DeleteModel : PageModel
    {
        private readonly BuyList _buylist;

        public DeleteModel(BuyList buylist)
        {
            _buylist = buylist;           
        }
    

        [BindProperty]
        public Buy Buy { get; set; }
    public IActionResult OnGetAsync()
        {
            Buy = _buylist.Get();
            if (Buy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            Buy = _buylist.Get();
            while (Buy != null)
            {
                if (Buy != null)
                {
                    _buylist.Delete(Buy.Id);
                }
                Buy = _buylist.Get();
            }

                return RedirectToPage("./Index");
        }
    }
}
