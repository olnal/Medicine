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
    public class DetailsModel : PageModel
    {
        private readonly Medicine.Data.RazorPagesContext _context;

        public DetailsModel(Medicine.Data.RazorPagesContext context)
        {
            _context = context;
        }

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
    }
}
