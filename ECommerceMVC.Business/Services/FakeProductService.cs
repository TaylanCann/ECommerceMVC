using ECommerceMVC.Dtos.Requests;
using ECommerceMVC.Dtos.Responses;
using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.Services
{
    public class FakeProductService : IProductService
    {
        private List<Product> _products;
        public FakeProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "MacBook Pro1" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 2, Name = "MacBook Pro2" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 3, Name = "MacBook Pro3" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 4, Name = "MacBook Pro4" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=2,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 5, Name = "MacBook Pro5" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=2,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 6, Name = "MacBook Pro6" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                 new Product { Id = 7, Name = "MacBook Pro5" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=3,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 8, Name = "MacBook Pro6" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"}, 
            };

        }

        //public Task<int> AddProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<int> AddProduct(AddProductRequest product)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProducts()
        {
                return _products;
        }

        //Task<ICollection<Product>> IProductService.GetProducts()
        //{
        //    throw new NotImplementedException();
        //}

        Task<ICollection<ProductListResponse>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
