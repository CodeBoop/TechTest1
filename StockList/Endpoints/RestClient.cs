using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockList
{
    public class RestClient
    {

        private HttpClient Client { get; }

        private static Uri RestApiUri { get; }


        static RestClient()
        {
            var url = ConfigurationManager.AppSettings["RestApiUri"];
            RestApiUri = new Uri(url);
        }


        public RestClient(string baseUrl)
        {

            Client = new HttpClient()
            {
                BaseAddress = new Uri(RestApiUri, baseUrl)
            };

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<T> Get<T>(string url)
        {
            return Client.GetFromJsonAsync<T>(url);
        }

    }
}
