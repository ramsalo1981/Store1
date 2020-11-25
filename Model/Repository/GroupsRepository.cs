using Market.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model.Repository
{
    public class GroupsRepository : AllFunction<Groups_Class>
    {
        private readonly StoreDb db;

        public GroupsRepository(StoreDb db)
        {
            this.db = db;
        }
        public void Add(Groups_Class tClass)
        {
            db.Groups.Add(tClass);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var group = Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
        }

        public void Edit(Groups_Class tClass, int id)
        {
            // var group = Find(id);
            //group.GroupName = tClass.GroupName;
            db.Groups.Update(tClass);
            db.SaveChanges();
        }

        public Groups_Class Find(int id)
        {
            var group = db.Groups.SingleOrDefault(g => g.Id == id);
            return group;
        }

        public List<Groups_Class> GetAll()
        {
            return db.Groups.ToList();
        }
    }
}
