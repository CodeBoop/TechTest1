using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository.Context;
using Microsoft.EntityFrameworkCore;

namespace EFRepository.Repositories
{
    public abstract class BaseRepository
    {

        protected AppDbContext Context => ContextFactory.CreateDbContext();
        private IDbContextFactory<AppDbContext> ContextFactory { get; }

        protected BaseRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }


        protected IQueryable<T> EmptyQueryable<T>() => Enumerable.Empty<T>().AsQueryable();

    }
}
