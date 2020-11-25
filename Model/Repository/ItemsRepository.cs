using Market.Model.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model.Repository
{
    public class ItemsRepository : AllFunction<CItems>
    {
        private readonly StoreDb db;

        public ItemsRepository(StoreDb db)
        {
            this.db = db;
        }
        public void Add(CItems tClass)
        {
            db.Items.Add(tClass);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Find(id);
            db.Items.Remove(item);
            db.SaveChanges();

        }

        public void Edit(CItems tClass, int id)
        {
            ////var item = Find(id);
            //db.Items.Update(tClass);
            

            var item = Find(id);
            item.ItemName = tClass.ItemName;
            item.ItemPrice = tClass.ItemPrice;
            item.Groups = tClass.Groups;
            item.ImagePath = tClass.ImagePath;
            db.SaveChanges();
        }

        public CItems Find(int id)
        {
            var item = db.Items.SingleOrDefault(x => x.Id == id);
            return item;
        }

        public List<CItems> GetAll()
        {
            //return db.Items.Include(I => I.Groups).ToList();

            return db.Items.ToList();
        }
    }
}
