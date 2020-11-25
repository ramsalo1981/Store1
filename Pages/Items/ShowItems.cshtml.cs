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
    public class ShowItemsModel : PageModel
    {
        private readonly ItemsRepository _mItem;
        private readonly GroupsRepository mGroup;

        public List<CItems> AllItems { get; set; }
        public List<Groups_Class> AllGroups { get; private set; }

        public ShowItemsModel(ItemsRepository mItem , GroupsRepository mGroup)
        {
            _mItem = mItem;
            this.mGroup = mGroup;
        }
       
        public void OnGet()
        {
            AllItems = _mItem.GetAll();
            AllGroups = mGroup.GetAll();
        }
    }
}
