using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using DTOShared.DTOs;

namespace TechTest1.Helpers
{
    public static class CategoryExtensions
    {

        public static CategoryDto ToDto(this Category dom)
        {
            return new CategoryDto
            {
                Id = dom.Id,
                Name = dom.Name
            };
        }

        public static IEnumerable<CategoryDto> ToDto(this IQueryable<Category> doms)
        {
            if(doms==null)
                return new CategoryDto[0];

            return doms.AsEnumerable().Select(ToDto);
        }

    }
}
