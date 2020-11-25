using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly ItemsRepository mItem;
        private readonly GroupsRepository mGroups;

        public CItems Item { get; set; }
        public List<Groups_Class> AllGroups { get; private set; }

        public DetailsModel(ItemsRepository mItem, GroupsRepository mGroups)
        {
            this.mItem = mItem;
            this.mGroups = mGroups;
        }
        public void OnGet(int id)
        {
            Item = mItem.Find(id);
            AllGroups = mGroups.GetAll();
        }
    }
}
