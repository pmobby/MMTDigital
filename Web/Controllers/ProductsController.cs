using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.DTOs;
using Web.Core.Entities;
using Web.Core.Interfaces;

namespace Web.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        public ProductsController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetProducts()
        {
            var featuredProducts = await _productServices.GetFeaturedProducts();
            var products = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(featuredProducts.ToList());

            return Ok(products);
        }


        [HttpGet("categories")]
        public async Task<ActionResult<CategoryDTO>> GetCategories()
        {
            var categoryList = await _productServices.GetCategoriesAsync();
            var categories = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDTO>>(categoryList.ToList());

            return Ok(categories);
        }


        [HttpGet("{categoryId}")]
        public async Task<ActionResult<ProductDTO>> GetProductsByCategories(int categoryId)
        {
            var productsByCategory = await _productServices.GetProductByCategoriesAsync(categoryId);
            var products = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(productsByCategory);

            return Ok(products);
        }
    }
}
