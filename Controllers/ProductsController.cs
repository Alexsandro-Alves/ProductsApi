using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(Guid id) 
        {
            var product = await _productRepository.Get(id);
            return product;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new() 
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
                OriginTimestampUtc = DateTime.Now,
            };

            await _productRepository.Add(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, UpdateProductDto updateProductDto)
        {
            Product product = new()
            {
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
            };

            await _productRepository.Update(product);
            return Ok();
        }
        
    }
}