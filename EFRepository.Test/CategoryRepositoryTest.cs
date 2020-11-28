using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using EFRepository.Context;
using EFRepository.Repositories;
using EFRepository.Test.Moq;
using FluentAssertions;
using Xunit;

namespace EFRepository.Test
{
    public class CategoryRepositoryTest 
    {

        private AppDbContext Context { get; }
        private ICategoryRepository Repo { get; }
        public CategoryRepositoryTest()
        {
            var factory = new DbFactoryMock();
            Context = factory.CreateDbContext();
            Repo = new CategoryRepository(factory);
        }

        [Fact]
        public void GetAllTest()
        {
            var items = Repo.GetAll().ToArray();
            items.Should().BeEquivalentTo(Context.Categories);
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
            var item = await Repo.Get(id);
            var expected = Context.Categories.FirstOrDefault(i => i.Id == id);
            item.Should().BeEquivalentTo(expected);
        }

    }
}
