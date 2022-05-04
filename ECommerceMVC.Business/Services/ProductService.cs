using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.Services
{
    public class ProductService : IProductService
    {
        private ECommerceDbContext dbContext;
        public ProductService(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICollection<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
