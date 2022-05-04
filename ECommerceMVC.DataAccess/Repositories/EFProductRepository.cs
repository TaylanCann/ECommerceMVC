using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private ECommerceDbContext context;
        public EFProductRepository(ECommerceDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Product entity)
        {
            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            return await context.Products.ToListAsync();
        }

        public Task<Product> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
