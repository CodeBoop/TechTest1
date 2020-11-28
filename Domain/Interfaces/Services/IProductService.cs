using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {

        IQueryable<Product> GetAll();

        IQueryable<Product> GetFeatured();

        IQueryable<Product> GetCategory(int categoryId);


    }
}
