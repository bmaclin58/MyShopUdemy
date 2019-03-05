using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            //looks at the web.config and finds the defination for DefaultConnection
            :base("DefaultConnection"){

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
//https://stackoverflow.com/questions/11231934/create-database-permission-denied-in-database-master-ef-code-first