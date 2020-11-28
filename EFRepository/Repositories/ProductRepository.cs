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
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(IDbContextFactory<AppDbContext> contextFactory) : base(contextFactory)
        {
        }


        public IQueryable<Product> GetAll()
        {
            return Context.Products;
        }


        //ToDo: change this to a flag on the product, but we'd need a user interface so they could go in and flag the items for that, otherwise we'd have to remember when inserting into the database.
        private static readonly HashSet<string> FeaturedSkus = new HashSet<string>() {"1", "2", "3"};
        public IQueryable<Product> GetFeatured()
        {
            return Context.Products.Where(i => FeaturedSkus.Contains(i.Sku.Substring(0, i.Sku.Length - 3)));
        }

        // We're using substring here so we can build a SQL statement rather then doing it in memory. Preferably I'd have Categories as a foreign key, but I need more information on the SKUs before I can make changes.
        public IQueryable<Product> GetCategory(int categoryId)
        {
            var context = Context;

            var r = (from p in context.Products
                join c in context.Categories on p.Sku.Substring(0, p.Sku.Length - 3) equals c.SkuPrefix
                where c.Id == categoryId
                select p);

            return r;
        }


    }
}
