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
    public class ShowGroupsModel : PageModel
    {
        private readonly GroupsRepository g_Method;
        public List<Groups_Class> AllGroups { get; set; }
        public ShowGroupsModel(GroupsRepository G_Method)
        {
            g_Method = G_Method;
        }
        public void OnGet()
        {
            AllGroups = g_Method.GetAll();
        }
    }
}
