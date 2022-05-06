using AutoMapper;
using ECommerceMVC.Dtos.Requests;
using ECommerceMVC.Dtos.Responses;
using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductListResponse>();
            CreateMap<AddProductRequest,Product>();
            CreateMap<UpdateProductRequest,Product>();

        }
    }
}
