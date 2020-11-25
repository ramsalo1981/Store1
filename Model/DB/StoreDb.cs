using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model.DB
{
    public class StoreDb : DbContext
    {
        public StoreDb(DbContextOptions<StoreDb> options): base(options)
        {

        }
       public DbSet <Groups_Class> Groups { get; set; }
       public DbSet <CItems> Items { get; set; }
    }
}
