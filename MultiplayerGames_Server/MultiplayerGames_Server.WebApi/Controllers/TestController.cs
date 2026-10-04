using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MultiplayerGames_Server.Application.UseCases.Test;
using MultiplayerGames_Server.Infrastructure.SignalR.Hubs.XOGameHub;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    [Route("api/v1/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> IncreaseCounter()
        {
            return Ok(await _testService.IncreaseCounterAsync());
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <response code="201">Returns the newly created product.</response>
        /// <response code="400">If the product is invalid.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product product)
        {
            await Task.Delay(1000); // Simulate some processing time
            return Ok(product);
        }

        /// <summary>
        /// Represents a product in the catalog.
        /// </summary>
        public class Product
        {
            /// <summary>
            /// The unique identifier for the product.
            /// </summary>
            /// <example>12345</example>
            /// <example>2342</example>
            public int Id { get; set; }

            /// <summary>
            /// The name of the product.
            /// </summary>
            /// <example>Wireless Mouse</example>
            /// <example>Rice</example>
            public string Name { get; set; } = string.Empty;
        }
    }
}
