using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository Repo { get; }

        public ProductService(IProductRepository repo)
        {
            Repo = repo;
        }

        public IQueryable<Product> GetAll()
        {
            return Repo.GetAll();
        }

        public IQueryable<Product> GetFeatured()
        {
            return Repo.GetFeatured();
        }

        public IQueryable<Product> GetCategory(int categoryId)
        {
            return Repo.GetCategory(categoryId);
        }

    }
}
