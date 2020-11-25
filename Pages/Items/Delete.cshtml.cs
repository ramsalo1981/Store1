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
    public class DeleteModel : PageModel
    {
        private readonly ItemsRepository mItem;

        public DeleteModel(ItemsRepository mItem)
        {
            this.mItem = mItem;
        }
        [BindProperty]
        public CItems Item { get; private set; }

        public void OnGet(int id)
        {
            Item = mItem.Find(id); 
        }

        public IActionResult OnPost(int id)
        {
            mItem.Delete(id);
            return RedirectToPage("/Items/ShowItems");
        }
    }
}
