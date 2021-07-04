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

namespace Medicine.Pages.DrugTypes
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
        public DrugType DrugType { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editedType = _typelist.Get(id);
            if (editedType == null)
            {
                return NotFound();
            }
            DrugType = new DrugType()
            {
                Id = editedType.Id,
                Type = editedType.Type
            };
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var tempDrug = _druglist.Get(DrugType);
            var editedDrug = new Drug
            {
                Id = tempDrug.Id,
                Name = tempDrug.Name,
                Type = DrugType,
                Price = tempDrug.Price,
                Count = tempDrug.Count
            };

            //editedDrug.Type.Type = "Sho popalo";

            try
            {
                _typelist.Edit(DrugType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(DrugType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
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
            
            catch (InvalidOperationException)
            {

            }
            return RedirectToPage("./Index");
        }

        private bool DrugExists(int id)
        {
            return _druglist.Get(id) != null;
        }
        private bool TypeExists(int id)
        {
            return _typelist.Get(id) != null;
        }


    }
}
