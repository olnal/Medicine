using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medicine.Data;
using Medicines.Models;

namespace Medicine.Pages.Drugs
{
    public class CreateModel : PageModel
    {
        private readonly Medicine.Data.RazorPagesContext _context;

        public CreateModel(Medicine.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Drug Drug { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drugs.Add(Drug);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
