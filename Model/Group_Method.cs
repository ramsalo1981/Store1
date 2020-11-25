using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model
{
    public class Group_Method
    {
        public List<Groups_Class> AllGroups { get; set; }
        public Groups_Class Group { get; set; }
        public Group_Method()
        {
            AllGroups = new List<Groups_Class>()
            {
                new Groups_Class{Id= 1, GroupName= "freezers"},
                new Groups_Class{Id=2, GroupName="legumes"},
                new Groups_Class{Id=3, GroupName="oils"}
            };
        }

        

        public List<Groups_Class> GetAllGroups()
        {

            return AllGroups;
        }

        

        public void AddGroup(Groups_Class newGroup)
        {
            AllGroups.Add(newGroup);
        }

        public Groups_Class GetGroup(int id)
        {
            Group = AllGroups.SingleOrDefault(x => x.Id == id);
            return Group;
        }

        public void EditGroup(Groups_Class EGroup, int id)
        {
            Group = AllGroups.SingleOrDefault(x => x.Id == id);
            Group.GroupName = EGroup.GroupName;
        }

        //internal Groups_Class DeleteGroup(int id)
        //{
        //    Group = AllGroups.SingleOrDefault(x => x.Id == id);

        //}
        internal void DeleteGroup( int id)
        {
            Group = AllGroups.SingleOrDefault(x => x.Id == id);
            AllGroups.Remove(Group);
        }

    }
}
