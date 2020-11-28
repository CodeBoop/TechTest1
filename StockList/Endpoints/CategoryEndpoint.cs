using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTOShared.DTOs;
using StockList.Endpoints;

namespace StockList
{
    public class CategoryEndpoint : BaseEndpoint
    {
        public CategoryEndpoint() : base("api/Categories/")
        {
        }

        public Task<IEnumerable<CategoryDto>> GetAll()
        {
            return Client.Get<IEnumerable<CategoryDto>>("");
        }
    }
}
