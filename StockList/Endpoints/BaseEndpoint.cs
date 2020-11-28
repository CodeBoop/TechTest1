using System;
using System.Collections.Generic;
using System.Text;

namespace StockList.Endpoints
{
    public class BaseEndpoint
    {
        protected RestClient Client { get; }

        public BaseEndpoint(string baseUrl)
        {
            Client = new RestClient(baseUrl);
        }

    }
}
