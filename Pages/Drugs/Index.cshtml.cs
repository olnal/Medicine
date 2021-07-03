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
    public class IndexModel : PageModel
    {
        private readonly DrugList _druglist;

        public IndexModel(DrugList druglist)
        {
            _druglist=druglist;
        }

        public IList<Drug> Drug { get;set; }

        public async Task OnGetAsync()
        {
            Drug = _druglist.GetAll();
        }
    }
}
