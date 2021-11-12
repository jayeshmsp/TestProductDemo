using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.DataAccessLayer.Entities;
using Product.DataAccessLayer.Repository;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<List<ProductDetailModel>> ReadAll(ProductFilterModel filter);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDetailModel>> ReadAll(ProductFilterModel filter)
        {
            var result = await _productRepository.ReadAll(_mapper.Map<ProductFilterEntity>(filter));
            return _mapper.Map<List<ProductDetailModel>>(result);
        }

    }
}
