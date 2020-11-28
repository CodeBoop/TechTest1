using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Models;
using EFRepository.Context;
using Microsoft.EntityFrameworkCore;

namespace EFRepository.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDbContextFactory<AppDbContext> contextFactory) : base(contextFactory)
        {
        }

        public IQueryable<Category> GetAll()
        {
            return Context.Categories;
        }

        public Task<Category> Get(int id)
        {
            return Context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        }


    }
}
