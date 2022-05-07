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
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            #region FirstRealDatas
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Phone", },

                new Category { Id = 2, Name = "Computer", },

                new Category { Id = 3, Name = "Tablet" }

            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "iPhone 11",
                    CategoryId = 1,
                    Price = 7000,
                    Discount = 0.02,
                    Description = "Awasome",
                    ImageURL = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/113155-2_large.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung",
                    CategoryId = 1,
                    Price = 7000,
                    Discount = 0.02,
                    Description = "Cool",
                    ImageURL = "https://productimages.hepsiburada.net/s/44/550/10769576230962.jpg/format:webp"

                },
                new Product
                {
                    Id = 3,
                    Name = "Xiomi",
                    CategoryId = 1,
                    Price = 7000,
                    Discount = 0.02,
                    Description = "Chang Ching Chong",
                    ImageURL = "https://productimages.hepsiburada.net/s/198/550/110000168630735.jpg/format:webp"

                },
                new Product
                {
                    Id = 4,
                    Name = "MacBook Pro1",
                    CategoryId = 2,
                    Price = 20000,
                    Discount = 0.09,
                    Description = "Interesting",
                    ImageURL = "https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"
                },
                new Product
                {
                    Id = 5,
                    Name = "Casper",
                    CategoryId = 2,
                    Price = 7000,
                    Discount = 0.02,
                    Description = "Ghost",
                    ImageURL = "https://productimages.hepsiburada.net/s/203/550/110000176911589.jpg/format:webp"

                },
                new Product
                {
                    Id = 6,
                    Name = "Monster",
                    CategoryId = 2,
                    Price = 7000,
                    Discount = 0.02,
                    Description = "Canavar",
                    ImageURL = "https://productimages.hepsiburada.net/s/108/550/110000052006351.jpg/format:webp"

                }
            );
            #endregion

            #region Second Real Datas
            
            modelBuilder.Entity<User>().HasData(

               new User 
               { 
                   Id = 1,
                   FullName = "Taylan Can Hardal",
                   UserName = "T",
                   Password = "123",
                   EMail = "taylancanh@gmail.com",
                   Role = "Admin"
               },

               new User
               {
                   Id = 2,
                   FullName = "Editör Can Hardal2",
                   UserName = "T2",
                   Password = "123",
                   EMail = "editorcanh2@gmail.com",
                   Role = "Editor"
               },

               new User
               {
                   Id = 3,
                   FullName = "Client Can Hardal3",
                   UserName = "T3",
                   Password = "123",
                   EMail = "clientcanh3@gmail.com",
                   Role = "Client"
               }

               

           );

            #endregion
        }
    }
}
