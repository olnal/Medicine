using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.DrugTypes
{
    public class CreateModel : PageModel
    {
        private readonly TypeList _typelist;

        public CreateModel(TypeList typelist)
        {
            _typelist = typelist;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DrugType DrugType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _typelist.Add(DrugType);
            

            return RedirectToPage("./Index");
        }
    }
}
