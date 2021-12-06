using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("/product/{id}")]
        public Object Get(string id)
        {
            return new
            {
                id = id,
                type = "CREDIT_CARD",
                name = "28 Degrees"
            };

        }

        [HttpGet]
        public Object Products()
        {
            return new[]{new {
                id = 1,
                type = "CREDIT_CARD",
                name = "28 Degrees"
            },new {
                id = 2,
                type = "CREDIT_CARD",
                name = "Apple"
            }}
           ;

        }
    }
}
