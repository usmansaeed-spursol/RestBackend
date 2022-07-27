using Microsoft.AspNetCore.Mvc;
using PersonalProduct.API.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using PersonalCompany.PersonalProduct.BL;
using Sentry;
using PersonalCompany.PersonalProduct.Models;
using Mapster;
using PersonalProduct.API.Models.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProduct.API.Controllers
{
    [Route("api/Product")]
    [SwaggerResponse(401, "Unauthorized Requeset", Type = typeof(ErrorResponse))]
    [SwaggerResponse(400, "Bad Request", Type = typeof(ErrorResponse))]
    [SwaggerResponse(500, "Server Failure", Type = typeof(ErrorResponse))]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ProductService productService = new ProductService();
                return Ok(productService.GetAll());
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return BadRequest();
            }

        }

        // GET api/<ProductController>/5
        [SwaggerResponse(200, "Success", Type = typeof(CustomerTypeResponse))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductService productService = new ProductService();
                {
                    Product product = productService.GetById(id);
                    ProductResponse productResponse = product.Adapt<ProductResponse>();
                    return Ok(productResponse);
                }
            }
            catch (Exception ex)
            {
                //Sentry code;
                return BadRequest(new ErrorResponse("Invalid"));
            }
        }

        [HttpPost]
        public IActionResult Post(ProductRequest productRequest)
        {
            Product product = productRequest.Adapt<Product>();
            ProductService productService = new ProductService();
            int result = productService.Add(product);
            if(result != -1)
            {
                return Ok("User added succesfully");
            }
            else
            {
                return BadRequest("Not added succesfully");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductRequest productRequest)
        {
            try
            {
                ProductService productService = new ProductService();
                Product product = productService.GetById(id);
                if (product == null)
                {
                    throw new Exception("User does not exist");
                }
                else
                {
                    product = productRequest.Adapt(product);
                    int response = productService.Update(product);
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureException(ex);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [SwaggerResponse(200, "Success")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductService productService = new ProductService();
            int response = productService.Delete(id);
            if(response == 1)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
