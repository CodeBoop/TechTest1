using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces.Services;
using Domain.Models;
using Moq;
using Newtonsoft.Json;

namespace TechTest1.Test.Moq
{
    public class CategoryServiceMoq : Mock<ICategoryService>
    {
        private const string Json =
            "[{\"id\":1,\"name\":\"Home\",\"skuPrefix\":\"1\"},{\"id\":2,\"name\":\"Garden\",\"skuPrefix\":\"2\"},{\"id\":3,\"name\":\"Electronics\",\"skuPrefix\":\"3\"},{\"id\":4,\"name\":\"Fitness\",\"skuPrefix\":\"4\"},{\"id\":5,\"name\":\"Toys\",\"skuPrefix\":\"5\"}]";

        private static IQueryable<Category> Items = JsonConvert.DeserializeObject<IEnumerable<Category>>(Json).AsQueryable();

        public CategoryServiceMoq MoqGet(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            Setup(i => i.Get(It.Is<int>(j => j == id))).ReturnsAsync(item);
            return this;
        }

        public CategoryServiceMoq MoqGetAll()
        {
            Setup(i => i.GetAll()).Returns(Items);
            return this;
        }

    }
}
