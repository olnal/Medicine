using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medicine.Data;
using Medicine.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicine.Pages.Drugs
{
    public class CreateModel : PageModel
    {
        private readonly DrugList _druglist;
        private readonly TypeList _typelist;
        public CreateModel(DrugList druglist, TypeList typelist)
        {
            _druglist = druglist;
            _typelist = typelist;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DrugView DrugView { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
            
            var addDrug=new Drug
            {
                Id = DrugView.Id,
                Name = DrugView.Name,
                Type = _typelist.Get(DrugView.Type),
                Price = DrugView.Price,
                Count = DrugView.Count
            };
            try
            {
                _druglist.Add(addDrug);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(addDrug.Id))
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
