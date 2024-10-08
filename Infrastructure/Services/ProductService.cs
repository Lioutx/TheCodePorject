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

        public async Task<bool> CreateOrUpdate(Product product)
        {
            ProductDto productDto = _mapper.Map<ProductDto>(product);

            if (productDto.Id.HasValue && productDto.Id > 0)
            {
                return await _productRepository.Update(productDto);
            }

            int? newProductId = await _productRepository.Create(productDto);

            return newProductId.HasValue && newProductId.Value > 0;
        }

        public async Task<Product> GetProduct(int productId)
        {
            ProductDto productDto = await _productRepository.Get(productId);
            Product product = _mapper.Map<Product>(productDto);

            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<ProductDto> productsDto = await _productRepository.GetAll();

            List<Product> products = productsDto.Select(x => _mapper.Map<Product>(x)).ToList();

            return products;
        }

        public async Task<bool> Delete(int productId)
        {
            bool success = await _productRepository.Delete(productId);
            return success;
        }
    }
}