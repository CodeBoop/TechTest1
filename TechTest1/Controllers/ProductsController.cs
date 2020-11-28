using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Helpers;
using Domain.Interfaces.Services;
using Domain.Models;
using DTOShared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTest1.Helpers;

namespace TechTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductService ProductService { get; }

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }


        [HttpGet("{categoryId}")]
        public IEnumerable<ProductDto> GetAll(int categoryId)
        {
            return ProductService.GetCategory(categoryId).ToDto();
        }

        [HttpGet("Featured")]
        public IEnumerable<ProductDto> GetFeatured() => ProductService.GetFeatured().ToDto();

    }
}
