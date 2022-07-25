using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Products;
using GeneralStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeneralStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.CreateProductAsync(request))
                return Ok("Product created successfully");

            return BadRequest("Product could not be created.");
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductListItem>), 200)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{noteId:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int noteId)
        {
            var detail = await _service.GetProductByIdAsync(noteId);

            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductById([FromBody] ProductEdit request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateProductAsync(request)
            ? Ok("Product updated sucessfully.")
            : BadRequest("Product could not be updated.");
        }

        [HttpDelete("{noteId:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int noteId)
        {
            return await _service.DeleteProductAsync(noteId)
            ? Ok($"Product {noteId} was deleted successfully.")
            : BadRequest($"Product {noteId} could not be deleted.");
        }
    }
}