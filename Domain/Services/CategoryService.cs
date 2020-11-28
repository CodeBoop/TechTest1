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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository Repo { get; }

        public CategoryService(ICategoryRepository repo)
        {
            Repo = repo;
        }

        public IQueryable<Category> GetAll()
        {
            return Repo.GetAll();
        }

        public Task<Category> Get(int id)
        {
            return Repo.Get(id);
        }
    }
}
