using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Repositories;
using EFRepository.Context;
using EFRepository.Repositories;
using EFRepository.Test.Moq;
using FluentAssertions;
using Xunit;

namespace EFRepository.Test
{
    public class ProductRepositoryTest 
    {

        private AppDbContext Context { get; }
        private IProductRepository Repo { get; }

        public ProductRepositoryTest()
        {
            var factory = new DbFactoryMock();
            Context = factory.CreateDbContext();
            Repo = new ProductRepository(factory);
        }


        [Fact]
        public void FeaturedTest()
        {
            var items = Repo.GetFeatured().ToArray();

            var expectedSkus = new HashSet<string>() {"1", "2", "3"};
            var expected = Context.Products.Where(i => expectedSkus.Contains(i.Sku.Substring(0, 1)));

            items.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllTest()
        {
            var items = Repo.GetAll();
            items.Should().BeEquivalentTo(Context.Products);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        public void GetCategoryTest(int catId)
        {
            var items = Repo.GetCategory(catId).OrderBy(i=>i.Id).ToArray();
            var expected = Context.Products.Where(i => i.Sku.Substring(0,i.Sku.Length-3)==catId.ToString()).OrderBy(i => i.Id).ToArray();
            items.Should().HaveSameCount(expected);
            items.Should().BeEquivalentTo(expected);
        }

    }
}
