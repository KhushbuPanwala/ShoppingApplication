using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class ProductDatabaseContext : DbContext
    {
        public virtual DbSet<ProductDetail> ProductDetail { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source=(localdb)\ProjectsV13;Initial Catalog=ShoppingDetail;Integrated Security=True;Pooling=False
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ShoppingDetail;Integrated Security=True;Pooling=False");
        }
    }

}
