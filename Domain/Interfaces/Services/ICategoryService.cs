using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICategoryService
    {

        IQueryable<Category> GetAll();
        Task<Category> Get(int id);

    }
}
