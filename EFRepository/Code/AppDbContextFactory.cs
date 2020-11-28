using System;
using System.Collections.Generic;
using System.Text;
using EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFRepository.Code
{
    public class AppDbContextFactory : IDbContextFactory<AppDbContext>
    {

        private DbContextOptions<AppDbContext> Options { get; }

        public AppDbContextFactory(DbContextOptions<AppDbContext> options)
        {
            Options = options;
        }

        public AppDbContext CreateDbContext() => new AppDbContext(Options);
    }
}
