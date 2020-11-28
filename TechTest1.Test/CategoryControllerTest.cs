using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOShared.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTest1.Test.Moq;
using Xunit;

namespace TechTest1.Test
{
    public class CategoryControllerTest : BaseControllerTest
    {

        private CategoryServiceMoq CategoryService { get; }

        public CategoryControllerTest(WebApplicationFactory<Startup> fixture) : base(fixture)
        {
            CategoryService = new CategoryServiceMoq();
        }


        [Fact]
        public async Task GetAllTest()
        {
            CategoryService.MoqGetAll();
            var items =await Get<IEnumerable<CategoryDto>>("/api/categories");

            var expectedItems = CategoryService.Object.GetAll();

            items.Should().HaveSameCount(CategoryService.Object.GetAll());

            var zip = items.Zip(expectedItems, (dto, category) => new {dto, category});

            foreach (var pair in zip)
            {
                var dto = pair.dto;
                var cat = pair.category;

                dto.Name.Should().Equals(cat.Name);
                dto.Id.Should().Equals(cat.Id);
            }


        }



    }
}
