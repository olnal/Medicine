using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Drugs
{
    public class DeleteModel : PageModel
    {
        private readonly DrugList _druglist;
        private readonly BuyList _buylist;
        private readonly OrderList _orderlist;


        public DeleteModel(DrugList druglist, BuyList buylist, OrderList orderlist)
        {
            _druglist = druglist;
            _buylist = buylist;
            _orderlist = orderlist;

        }

        [BindProperty]
        public DrugView DrugView { get; set; }

        public IActionResult OnGetAsync(int? id)
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
            if (DrugView.Id == null)
            {
                return NotFound();
            }

            if (_buylist.Get(DrugView.Name) != null || _orderlist.Get(DrugView.Name)!=null)
            {
                _druglist.Delete(DrugView.Id);
                return RedirectToPage("./Index");

            }
            else
            {
                ViewData["Message"] = "Неможливо видалити, так як ліки знаходяться в списку замовлення або списку продажів";
                return Page();
            }           
            
        }
    }
}
