using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Drugs
{
    public class EditModel : PageModel
    {
        private readonly DrugList _druglist;
        private readonly TypeList _typelist;

        public EditModel(DrugList druglist, TypeList typelist)
        {
            _druglist = druglist;
            _typelist = typelist;
        }

        [BindProperty]
        public DrugView DrugView { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = _druglist.Get(id);

            if (drug == null)
            {
                return NotFound();
            }

            DrugView = new DrugView()
            {
                Id = drug.Id,
                Name = drug.Name,
                Type = drug.Type.Type,
                Price = drug.Price,
                Count = drug.Count
            };

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var DBType = _typelist.Get(DrugView.Type);

            if (DBType == null)
            {
                var nt = new DrugType
                {
                    Type = DrugView.Type
                };

                _typelist.Add(nt);

            }
            var editedDrug = new Drug
            {
                Id = DrugView.Id,
                Name = DrugView.Name,
                Type = DBType,
                Price = DrugView.Price,
                Count = DrugView.Count
            };

            try
            {
                _druglist.Edit(editedDrug);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(editedDrug.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
             return RedirectToPage("./Index");
         }

         private bool DrugExists(int id)
         {
             return _druglist.Get(id) != null;
         }
    }
}


