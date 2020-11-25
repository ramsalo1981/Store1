using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model
{
    public class MItem : AllFunction<CItems>
    {
        public List<CItems> AllItems { get; set; }

        public MItem(Group_Method G_Method)
        {
            AllItems = new List<CItems>
            {
                new CItems{Id= 1, ItemName="Bush", ItemPrice= 100, Groups=G_Method.GetGroup(1), ImagePath="eagle.jpg" },
                new CItems{Id= 2, ItemName="Bean", ItemPrice= 60, Groups=G_Method.GetGroup(2), ImagePath="redbird.jpg" },
                new CItems{Id= 3, ItemName="Olive", ItemPrice= 80, Groups=G_Method.GetGroup(3), ImagePath="yellowBird.jpg" }
            };
        }
        public void Add(CItems tClass)
        {
            var MaxId = AllItems.Max(x => x.Id);
            tClass.Id = MaxId + 1;
            AllItems.Add(tClass);
        }

        public void Delete(int id)
        {
            var item = Find(id);
            AllItems.Remove(item);
        }

        public void Edit(CItems tClass, int id)
        {
            var item = Find(id);
            item.ItemName = tClass.ItemName;
            item.ItemPrice = tClass.ItemPrice;
            item.Groups = tClass.Groups;
            item.ImagePath = tClass.ImagePath;
        }

        public CItems Find(int id)
        {
            var item = AllItems.SingleOrDefault(x => x.Id == id);
            return item;
        }

        public List<CItems> GetAll()
        {
            return AllItems;
        }
    }
}
