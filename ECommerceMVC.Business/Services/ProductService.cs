using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.DataAccess.Repositories;
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
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ICollection<Product>> GetProducts()
        {
            return await productRepository.GetAllEntities();
        }
    }
}
