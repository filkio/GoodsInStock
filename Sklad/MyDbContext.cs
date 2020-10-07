using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnectionString")
        { 
        
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
