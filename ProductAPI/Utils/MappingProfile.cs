using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.DataAccessLayer.Entities;
using ProductAPI.Models;

namespace ProductAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AuthModel, AuthEntity>();
            CreateMap<AuthDetailEntity, AuthDetailModel>();

            // Product Mapper Configuration
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductFilterModel, ProductFilterEntity>();

            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductDetailEntity, ProductDetailModel>();
        }
    }
}
