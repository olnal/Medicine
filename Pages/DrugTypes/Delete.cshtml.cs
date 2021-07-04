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
    public class DeleteModel : PageModel
    {
        private readonly DrugList _druglist; 
        private readonly TypeList _typelist;

        public DeleteModel(DrugList druglist, TypeList typelist)
        {
            _druglist = druglist; 
            _typelist = typelist;
        }

        [BindProperty]
        public DrugType DrugType { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugtype = _typelist.Get(id);
            //DrugType = await _context.DrugTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (drugtype == null)
            {
                return NotFound();
            }
            DrugType = new DrugType()
            {
                Id = drugtype.Id,
                Type = drugtype.Type
            };
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_druglist.Get(DrugType) == null)
            {
                _typelist.Delete(DrugType.Id); 
                return RedirectToPage("./Index");

            }
            else
            {
                ViewData["Message"] = "Неможливо видалити, так як в довіднику ліків існують ліки з таким типом";
                return Page();
            }

                        
        }
    }
}
