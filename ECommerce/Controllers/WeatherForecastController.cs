using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/products/{id}")]
        public Product Get(string id)
        {
            return new Product
            {
                id = id,
                type = "CREDIT_CARD",
                name = "28 Degrees"
            };

        }

        [HttpGet]
        public Product[] Products()
        {
            return new[]{new Product{
                id = "1",
                type = "CREDIT_CARD",
                name = "28 Degrees"
            },new Product{
                id = "2",
                type = "CREDIT_CARD",
                name = "Apple"
            }}
           ;

        }
    }
}
