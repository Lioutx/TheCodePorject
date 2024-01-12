﻿using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> GetProduct(int productId)
        {
            ProductDto productDto = await _productRepository.Get(productId);
            Product product = _mapper.Map<Product>(productDto);

            return product;
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}