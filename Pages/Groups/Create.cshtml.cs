using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Pages.Groups
{
    public class CreateModel : PageModel
    {
        
        private readonly GroupsRepository g_Method;
        [BindProperty]
        public Groups_Class NewGroup { get; set; }

        public CreateModel(GroupsRepository G_Method)
        {
            g_Method = G_Method;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            g_Method.Add(NewGroup);
            return RedirectToPage("/Groups/ShowGroups");
        }
    }
}
