using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Services;
using Domain.Test.Moq;
using FluentAssertions;
using Xunit;

namespace Domain.Test
{
    public class CategoryServiceTest 
    {

        private CategoryRepositoryMoq RepoMoq { get; }
        private ICategoryService Service { get; }
        public CategoryServiceTest()
        {
            RepoMoq = new CategoryRepositoryMoq();
            Service = new CategoryService(RepoMoq.Object);
        }


        [Fact]
        public void GetAllTest()
        {
            RepoMoq.MoqGetAll();
            var items = Service.GetAll().ToArray();
            items.Should().Equal(RepoMoq.Object.GetAll());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task GetTest(int id)
        {
            RepoMoq.MoqGet(id);
            var item = await Service.Get(id);
            var expected = await RepoMoq.Object.Get(id);
            item.Should().Be(expected);
        }

    }
}
