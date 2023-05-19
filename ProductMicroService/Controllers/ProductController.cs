using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Models;
using ProductMicroService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }
                
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product=_productRepository.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productRepository.InsertProduct(product);
            return CreatedAtAction(nameof(Get), product.Id);
        }
                
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if(product == null)
            {
                return NoContent();
            }
            _productRepository.UpdateProduct(product);
            return Ok();
        }
                
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
