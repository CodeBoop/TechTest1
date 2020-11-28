using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
using DTOShared.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTest1.Test.Moq;
using Xunit;

namespace TechTest1.Test
{
    public class ProductControllerTest : BaseControllerTest
    {

        private ProductServiceMoq ProductService { get; }

        public ProductControllerTest(WebApplicationFactory<TechTest1.Startup> fixture): base(fixture)
        {
            ProductService = new ProductServiceMoq();
        }


        [Fact]
        public async Task FeaturedTest()
        {
            ProductService.MockGetFeatured();
            var items = await Get<IEnumerable<ProductDto>>("/api/products/Featured");
            items.Should().HaveSameCount(ProductService.Object.GetFeatured());
            TestItemsAreSame(items, ProductService.Object.GetFeatured());


        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetCategoryTest(int catId)
        {
            ProductService.MockGetCategory(catId);
            var items = await Get<IEnumerable<ProductDto>>("/api/products/"+catId.ToString());
            items.Should().HaveSameCount(ProductService.Object.GetCategory(catId));
            TestItemsAreSame(items, ProductService.Object.GetCategory(catId));
        }


        private void TestItemsAreSame(IEnumerable<ProductDto> dtos, IEnumerable<Product> doms)
        {

            var zip = dtos.Zip(doms, (dto, product) => new {dto, product});

            foreach (var pair in zip)
            {
                var dto = pair.dto;
                var p = pair.product;

                dto.Sku.Should().Equals(p.Sku);
                dto.Description.Should().Equals(p.Description);
                dto.Price.Should().Equals(p.Price);
                dto.Name.Should().Equals(p.Name);
            }

        }






    }
}
