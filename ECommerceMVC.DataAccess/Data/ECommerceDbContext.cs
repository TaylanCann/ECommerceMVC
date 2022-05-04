using ECommerceMVC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DataAccess.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            #region FirstRealDatas
            //modelBuilder.Entity<Category>().HasData(

            //    new Category {  Id = 1, Name = "Phone", },

            //    new Category { Id = 2, Name = "Computer",},

            //    new Category { Id = 3, Name = "Tablet" }

            //);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        Name = "iPhone 11",
            //        CategoryId = 1,
            //        Price = 7000,
            //        Discount = 0.02,
            //        Description = "Awasome",
            //        ImageURL = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/113155-2_large.jpg"
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Name = "Samsung",
            //        CategoryId = 1,
            //        Price = 7000,
            //        Discount = 0.02,
            //        Description = "Cool",
            //        ImageURL = "https://productimages.hepsiburada.net/s/44/550/10769576230962.jpg/format:webp"

            //    },
            //    new Product
            //    {
            //        Id = 3,
            //        Name = "Xiomi",
            //        CategoryId = 1,
            //        Price = 7000,
            //        Discount = 0.02,
            //        Description = "Chang Ching Chong",
            //        ImageURL = "https://productimages.hepsiburada.net/s/198/550/110000168630735.jpg/format:webp"

            //    },
            //    new Product
            //    {
            //        Id = 4,
            //        Name = "MacBook Pro1",
            //        CategoryId = 2,
            //        Price = 20000,
            //        Discount = 0.09,
            //        Description = "Interesting",
            //        ImageURL = "https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"
            //    },
            //    new Product
            //    {
            //        Id = 5,
            //        Name = "Casper",
            //        CategoryId = 2,
            //        Price = 7000,
            //        Discount = 0.02,
            //        Description = "Ghost",
            //        ImageURL = "https://productimages.hepsiburada.net/s/203/550/110000176911589.jpg/format:webp"

            //    },
            //    new Product
            //    {
            //        Id = 6,
            //        Name = "Monster",
            //        CategoryId = 2,
            //        Price = 7000,
            //        Discount = 0.02,
            //        Description = "Canavar",
            //        ImageURL = "https://productimages.hepsiburada.net/s/108/550/110000052006351.jpg/format:webp"

            //    }
            //);
            #endregion
        }
    }
}
