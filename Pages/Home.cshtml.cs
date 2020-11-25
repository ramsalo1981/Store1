using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Market.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        [BindProperty]
        public string Mes { get; set; }
        public int N1 { get; set; }
        public void OnGet()
        {
            Mes = "Welcome Rami";
            N1 = 5;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //return RedirectToPage("/Items/ShowItems");
            return N1 == 5 ? RedirectToPage("/Items/ShowItems") : RedirectToPage("/Groups/ShowGroups");



        }
    }
}
