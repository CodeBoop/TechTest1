using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTOShared.DTOs;
using StockList.Endpoints;

namespace StockList
{
    public class ProductEndpoint : BaseEndpoint
    {


        public ProductEndpoint() : base("api/Products/") { }


        public Task<IEnumerable<ProductDisplay>> GetAll(int categoryId)
        {
            return Client.Get<IEnumerable<ProductDisplay>>(categoryId.ToString());
        }

        public Task<IEnumerable<ProductDisplay>> GetFeatured()
        {
            return Client.Get<IEnumerable<ProductDisplay>>("Featured");
        }

    }
}
