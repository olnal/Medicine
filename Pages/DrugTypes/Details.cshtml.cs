using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.DrugTypes
{
    public class DetailsModel : PageModel
    {
        private readonly Medicine.Data.RazorPagesContext _context;

        public DetailsModel(Medicine.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public DrugType DrugType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DrugType = await _context.DrugTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (DrugType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
