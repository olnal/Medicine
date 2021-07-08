using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine.Data;
using Medicine.Models;

namespace Medicine.Pages.Buys
{
    public class IndexModel : PageModel
    {
        private readonly BuyList _buylist;

        public IndexModel(BuyList buyList)
        {
            _buylist = buyList;
        }

        public IList<Buy> Buy { get;set; }

        public async Task OnGetAsync()
        {
            Buy =  _buylist.GetAll();
        }
    }
}
