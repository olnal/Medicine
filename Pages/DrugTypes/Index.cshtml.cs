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
    public class IndexModel : PageModel
    {
        private readonly Medicine.Data.RazorPagesContext _context;

        public IndexModel(Medicine.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<DrugType> DrugType { get;set; }

        public async Task OnGetAsync()
        {
            DrugType = await _context.DrugTypes.ToListAsync();
        }
    }
}
