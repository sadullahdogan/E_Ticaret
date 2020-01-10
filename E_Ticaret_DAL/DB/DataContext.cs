using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Ticaret_DLL.Models;
using E_Ticaret_Entity.Entity;

namespace E_Ticaret_DAL.DB
{
    public class DataContext:DbContext
    {
        public DataContext():base("MSSQL")
        {
            Database.SetInitializer(new DataInitilazier());
        }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ShippingDetails> ShippingDetails { get; set; }
    }
}
