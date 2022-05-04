using ECommerceMVC.Business.IServices;
using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private ECommerceDbContext dbContext;
        public CategoryService(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IList<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
    }
}
