using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {

        IQueryable<Product> GetAll();

        IQueryable<Product> GetFeatured();

        IQueryable<Product> GetCategory(int categoryId);

        
    }
}
