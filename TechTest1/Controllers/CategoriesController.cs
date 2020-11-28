using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models;
using DTOShared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTest1.Helpers;

namespace TechTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService CategoryService { get; }

        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }


        [HttpGet]
        public IEnumerable<Category> GetAll() => CategoryService.GetAll();

    }
}
