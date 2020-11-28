using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;

namespace EFRepository.Test.Moq
{

    public class DbFactoryMock : IDbContextFactory<AppDbContext>
    {
        private const string ProductJson =
            @"[{""id"":1,""sku"":""1001"",""name"":""Sofa"",""description"":""4 seater"",""price"":400.00},{""id"":2,""sku"":""1002"",""name"":""Sofa"",""description"":""5 seater"",""price"":500.00},{""id"":3,""sku"":""1003"",""name"":""Sofa"",""description"":""6 seater"",""price"":600.00},{""id"":4,""sku"":""1005"",""name"":""Chair"",""description"":""Wooden"",""price"":10.05},{""id"":5,""sku"":""2001"",""name"":""Lawn"",""description"":null,""price"":1000.00},{""id"":6,""sku"":""2002"",""name"":""Lawn Chair"",""description"":""A fancier wooden chair"",""price"":11.89},{""id"":7,""sku"":""2015"",""name"":""Plants"",""description"":""Green ones, blue ones, we've got them all"",""price"":10.00},{""id"":8,""sku"":""3001"",""name"":""IPhone M"",""description"":""It's the 1000th iteration of the IPhone"",""price"":999999.99},{""id"":9,""sku"":""3002"",""name"":""Windows 10 PC"",""description"":null,""price"":1000.99},{""id"":10,""sku"":""3003"",""name"":""Kettle"",""description"":""It uses electricity, that's why it's in this category"",""price"":1.00},{""id"":11,""sku"":""4001"",""name"":""Bumbbells"",""description"":""Which pandemic body are you going to have at the end?"",""price"":99.98},{""id"":12,""sku"":""4002"",""name"":""Tredmill"",""description"":""When running stationary is not up the street"",""price"":100.00},{""id"":13,""sku"":""4003"",""name"":""Skipping rope"",""description"":null,""price"":5.99},{""id"":14,""sku"":""5001"",""name"":""Bear"",""description"":""It's a stuffed toy"",""price"":9.50}]";

        private static IEnumerable<Product> Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(ProductJson);


        private const string CategoryJson =
            "[{\"id\":1,\"name\":\"Home\",\"skuPrefix\":\"1\"},{\"id\":2,\"name\":\"Garden\",\"skuPrefix\":\"2\"},{\"id\":3,\"name\":\"Electronics\",\"skuPrefix\":\"3\"},{\"id\":4,\"name\":\"Fitness\",\"skuPrefix\":\"4\"},{\"id\":5,\"name\":\"Toys\",\"skuPrefix\":\"5\"}]";

        private static IEnumerable<Category> Categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(CategoryJson);


        static DbFactoryMock()
        {
            var context = DbContext();
            context.Products.AddRange(Products);
            context.Categories.AddRange(Categories);
            context.SaveChanges();
        }





        private static AppDbContext DbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new AppDbContext(options);
        }


        public AppDbContext CreateDbContext()
        {
            return DbContext();
        }
    }

}
