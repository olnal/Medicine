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
        private readonly Medicine.Data.RazorPagesContext _context;

        public DeleteModel(Medicine.Data.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buy Buy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buy = await _context.Buys.FirstOrDefaultAsync(m => m.Id == id);

            if (Buy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buy = await _context.Buys.FindAsync(id);

            if (Buy != null)
            {
                _context.Buys.Remove(Buy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
