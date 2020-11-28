using Domain.Interfaces.Services;
using Domain.Services;
using Domain.Test.Moq;
using FluentAssertions;
using Xunit;

namespace Domain.Test
{
    public class ProductServiceTest 
    {

        private ProductRepositoryMoq RepoMoq { get; }
        private IProductService Service { get; }

        public ProductServiceTest()
        {
            RepoMoq = new ProductRepositoryMoq();
            Service = new ProductService(RepoMoq.Object);
        }


        [Fact]
        public void FeaturedTest()
        {
            RepoMoq.MockGetFeatured();
            var items = Service.GetFeatured();
            items.Should().Equal(RepoMoq.Object.GetFeatured());
        }

        [Fact]
        public void GetAllTest()
        {
            RepoMoq.MockGetAll();
            var items = Service.GetAll();
            items.Should().Equal(RepoMoq.Object.GetAll());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetCategoryTest(int catId)
        {
            RepoMoq.MockGetFeatured();
            var items = Service.GetCategory(catId);
            items.Should().Equal(RepoMoq.Object.GetCategory(catId));
        }

    }
}
