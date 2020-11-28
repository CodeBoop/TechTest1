using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using DTOShared.DTOs;

namespace TechTest1.Helpers
{
    public static class ProductExtensions
    {

        public static ProductDto ToDto(this Product dom)
        {
            return new ProductDto
            {
                Sku = dom.Sku,
                Description = dom.Description,
                Name = dom.Name,
                Price = dom.Price
            };
        }

        public static IEnumerable<ProductDto> ToDto(this IQueryable<Product> doms)
        {
            if (doms == null)
                return new ProductDto[0];

            return doms.AsEnumerable().Select(ToDto);
        }
    }
}
