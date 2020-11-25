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
    public class CreateModel : PageModel
    {
        private readonly ItemsRepository newItem;
        private readonly IWebHostEnvironment Hosting;

        [BindProperty]
        public CItems Item { get; set; }
        public string Message { get; private set; }
        public List<Groups_Class> AllGroups { get; set; }
        public GroupsRepository G_Method { get; }
        [BindProperty]
        public IFormFile RFile { get; set; }

        public CreateModel(ItemsRepository newItem, GroupsRepository G_Method, IWebHostEnvironment Hosting)
        {
            this.newItem = newItem;
            this.G_Method = G_Method;
           this.Hosting = Hosting;
        }
        public void OnGet()
        {
            AllGroups = SelectGroup();
            
        }

        public IActionResult OnPost()
        {

            if (RFile.FileName != null)
            {
                var FName = Path.GetFileName(RFile.FileName);
                var NewPath = Path.Combine(Hosting.WebRootPath, "Images", FName);
                RFile.CopyTo(new FileStream(NewPath, FileMode.Create));
                Item.ImagePath = FName;
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill All Fields");
                AllGroups = SelectGroup();
                return Page();
            }
            var groupId = Item.Groups.Id;
            if (groupId == 0)
            {
                Message = "You must select group";
                AllGroups = SelectGroup();
                return Page();
            }
            var group = G_Method.Find(groupId);
            Item.Groups = group;
            newItem.Add(Item);
            return RedirectToPage("/Items/ShowItems");
        }

        public List<Groups_Class> SelectGroup() 
        {
            List<Groups_Class> LGroups = new List<Groups_Class>();
            LGroups.Add(new Groups_Class { Id=0, GroupName="Select Group" });

            List<Groups_Class> AllGroupL = new List<Groups_Class>();
            AllGroupL = G_Method.GetAll();

            for (int i = 0; i < AllGroupL.Count; i++)
            {
                LGroups.Add(AllGroupL[i]);
            }

            return LGroups;
        }
    }
}
