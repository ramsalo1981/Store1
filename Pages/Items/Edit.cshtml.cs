using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly ItemsRepository mItem;
        private readonly GroupsRepository g_Method;
        private readonly IWebHostEnvironment Hosting;

        [BindProperty]
        public CItems Item { get; set; }
        [BindProperty]
        public IFormFile RFile { get; set; }
        public List<Groups_Class> AllGroups { get; set; }
        public EditModel(ItemsRepository mItem, GroupsRepository G_Method, IWebHostEnvironment Hosting)
        {
            this.mItem = mItem;
            g_Method = G_Method;
            this.Hosting = Hosting;
        }
        public void OnGet(int id)
        {
            Item = mItem.Find(id);
            AllGroups = g_Method.GetAll();
        }
        public IActionResult OnPost(int id)
        {
            if (RFile.FileName != null)
            {
                var FName = Path.GetFileName(RFile.FileName);
                var NewPath = Path.Combine(Hosting.WebRootPath, "Images", FName);
                RFile.CopyTo(new FileStream(NewPath, FileMode.Create));
                Item.ImagePath = FName;
                //var OldImageName = mItem.Find(id).ImagePath;
                //var OldPath = Path.Combine(Hosting.WebRootPath, "Images", OldImageName);
                //System.IO.File.Delete(OldPath);
            }
            var groupId = Item.Groups.Id;
            var group = g_Method.Find(groupId);
            Item.Groups = group;
            mItem.Edit(Item, id);
            return RedirectToPage("/Items/ShowItems");
        }
    }
}
