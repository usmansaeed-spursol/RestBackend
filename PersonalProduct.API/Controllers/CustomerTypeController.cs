using Microsoft.AspNetCore.Mvc;
using PersonalCompany.PersonalProduct.BL;
using PersonalCompany.PersonalProduct.Models;
using PersonalProduct.API.Models.Requests;
using PersonalProduct.API.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using Mapster;
using Sentry;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProduct.API.Controllers
{
    [Route("api/CustomerType")]
    [SwaggerResponse(401, "Unauthorized Requeset", Type = typeof(ErrorResponse))]
    [SwaggerResponse(400, "Bad Request", Type = typeof(ErrorResponse))]
    [SwaggerResponse(500, "Server Failure", Type = typeof(ErrorResponse))]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        //[Authorize]
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                CustomerTypeService CustomerType = new CustomerTypeService();
                return Ok(CustomerType.GetAll());
            }
            catch(Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return BadRequest();
            }
        }

        
        [SwaggerResponse(200, "Success", Type = typeof(CustomerTypeResponse))]
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            try
            {
                CustomerTypeService customerTypeService = new CustomerTypeService();
                {
                    CustomerType customerModel = customerTypeService.GetById(id);
                    CustomerTypeResponse customerResponse = customerModel.Adapt<CustomerTypeResponse>();
                    return Ok(customerResponse);
                }
            }
            catch (Exception ex)
            {
                //Sentry code;
                return BadRequest(new ErrorResponse("Invalid"));
            }
        }

        [SwaggerResponse(200, "Success", Type = typeof(CustomerTypeResponse))]
        [HttpPost]
        public IActionResult Post(CustomerTypeRequest customerTypeRequest)
        {
            CustomerType customerType = customerTypeRequest.Adapt<CustomerType>();
            CustomerTypeService customerTypeService = new CustomerTypeService();
            int userAdded = customerTypeService.Add(customerType);
            if (userAdded != -1)
                return Ok("User added succesfully");
            else
                return BadRequest("Not added succesfully");
        }

        // PUT api/<CustomerController>/5
        [SwaggerResponse(200, "Success", Type = typeof(CustomerTypeResponse))]
        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerTypeRequest customerTypeRequest)
        {
            try
            {
                CustomerTypeService customerTypeService = new CustomerTypeService();
                CustomerType customerType = customerTypeService.GetById(id);
                if (customerType == null)
                {
                    throw new Exception("User does not exist");
                }
                else
                {
                    customerType = customerTypeRequest.Adapt(customerType);
                    int userTypeId = customerTypeService.Update(customerType);
                    return Ok(userTypeId);
                }
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureException(ex);
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<CustomerController>/5
        [SwaggerResponse(200, "Success")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CustomerTypeService customerTypeService = new CustomerTypeService();
            int response = customerTypeService.Delete(id);
            if(response == 1)
                return Ok(response);
            else
                return BadRequest(response);

        }
    }
}
