using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Moq;
using Newtonsoft.Json;

namespace Domain.Test.Moq
{
    public class ProductRepositoryMoq : Mock<IProductRepository>
    {
        private const string Json =
            @"[{""id"":1,""sku"":""1001"",""name"":""Sofa"",""description"":""4 seater"",""price"":400.00},{""id"":2,""sku"":""1002"",""name"":""Sofa"",""description"":""5 seater"",""price"":500.00},{""id"":3,""sku"":""1003"",""name"":""Sofa"",""description"":""6 seater"",""price"":600.00},{""id"":4,""sku"":""1005"",""name"":""Chair"",""description"":""Wooden"",""price"":10.05},{""id"":5,""sku"":""2001"",""name"":""Lawn"",""description"":null,""price"":1000.00},{""id"":6,""sku"":""2002"",""name"":""Lawn Chair"",""description"":""A fancier wooden chair"",""price"":11.89},{""id"":7,""sku"":""2015"",""name"":""Plants"",""description"":""Green ones, blue ones, we've got them all"",""price"":10.00},{""id"":8,""sku"":""3001"",""name"":""IPhone M"",""description"":""It's the 1000th iteration of the IPhone"",""price"":999999.99},{""id"":9,""sku"":""3002"",""name"":""Windows 10 PC"",""description"":null,""price"":1000.99},{""id"":10,""sku"":""3003"",""name"":""Kettle"",""description"":""It uses electricity, that's why it's in this category"",""price"":1.00},{""id"":11,""sku"":""4001"",""name"":""Bumbbells"",""description"":""Which pandemic body are you going to have at the end?"",""price"":99.98},{""id"":12,""sku"":""4002"",""name"":""Tredmill"",""description"":""When running stationary is not up the street"",""price"":100.00},{""id"":13,""sku"":""4003"",""name"":""Skipping rope"",""description"":null,""price"":5.99},{""id"":14,""sku"":""5001"",""name"":""Bear"",""description"":""It's a stuffed toy"",""price"":9.50}]";

        private static IQueryable<Product> Items = JsonConvert.DeserializeObject<IEnumerable<Product>>(Json).AsQueryable();


        public ProductRepositoryMoq MockGetAll()
        {
            Setup(i => i.GetAll()).Returns(Items);
            return this;
        }

        public ProductRepositoryMoq MockGetCategory(int catId)
        {
            //bit of a hack, but we don't have a direct link to categories in the Product, which we really should. 
            var items = Items.Where(i => i.Sku.StartsWith(catId.ToString()));
            Setup(i => i.GetCategory(It.Is<int>(j => j == catId))).Returns(items);
            return this;
        }

        public ProductRepositoryMoq MockGetFeatured()
        {
            //bit of a hack, but we don't have a direct link to categories in the Product, which we really should.
            var cats = new HashSet<string>(){"1","2","3"};
            var items = Items.Where(i => cats.Contains(i.Sku.Substring(0, i.Sku.Length-3)));
            Setup(i => i.GetFeatured()).Returns(items);
            return this;
        }


    }
}
