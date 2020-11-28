using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {

        IQueryable<Category> GetAll();
        Task<Category> Get(int id);

    }
}
