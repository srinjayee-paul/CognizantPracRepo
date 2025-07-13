using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;
using System.Collections.Generic;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "Pen", Price = 10 },
            new Product { Id = 2, Name = "Notebook", Price = 50 }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            products.Add(product);
            return Ok(product);
        }
    }
}
