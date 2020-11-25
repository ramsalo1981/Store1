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
    public class DetailsModel : PageModel
    {
        private readonly GroupsRepository g_Method;

        public Groups_Class Group { get; set; }
        public DetailsModel(GroupsRepository G_Method)
        {
            g_Method = G_Method;
        }
        public void OnGet(int id)
        {
            Group = g_Method.Find(id);
        }

        
    }
}
