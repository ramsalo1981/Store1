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
    public class DeleteModel : PageModel
    {
        private readonly GroupsRepository g_Method;
        [BindProperty]
        public Groups_Class Group { get; set; }
        public DeleteModel(GroupsRepository G_Method)
        {
            g_Method = G_Method;
        }
        public void OnGet(int id)
        {
            Group = g_Method.Find(id);
        }
        public IActionResult OnPost(int id)
        {
            g_Method.Delete( id);
            return RedirectToPage("/Groups/ShowGroups");
        }
    }
}
