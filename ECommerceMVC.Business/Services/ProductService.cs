using AutoMapper;
using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.DataAccess.Repositories;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddProduct(AddProductRequest request)
        {
            //var product = new Product
            //{
            //    CategoryId = request.CategoryId,
            //    Name = request.Name,
            //    Description = request.Description,
            //    CreatedDate = DateTime.Now,
            //    Discount = request.Discount,
            //    ImageURL = request.ImageURL,
            //    Price = request.Price,
            //};

            var product = mapper.Map<Product>(request);
            return await productRepository.Add(product);
        }

        public async Task<ICollection<ProductListResponse>> GetProducts()
        {
            var products = await productRepository.GetAllEntities();
            //var productListResponses = new List<ProductListResponse>();

            //products.ToList().ForEach(p => productListResponses.Add(new ProductListResponse 
            //{
            //    CategoryId = p.CategoryId,
            //    Description = p.Description,
            //    Discount = p.Discount,
            //    ImageURL = p.ImageURL,
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price
            //}));

            var productListResponses = mapper.Map<List<ProductListResponse>>(products);
            return productListResponses;
        }
    }
}
