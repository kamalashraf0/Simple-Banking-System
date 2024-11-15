using Application.Services.CustomerService;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Simple_Banking_System.HandleResponses;

namespace Simple_Banking_System.Controllers
{

    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var customers = await customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromForm] CustomerCreateDto customer)
        {
            if (customer == null)
            {
                return BadRequest(new ApiException(400));
            }

            await customerService.AddCustomerAsync(customer);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerCreateDto>> EditCustomer([FromRoute] int id, [FromForm] CustomerCreateDto customer)
        {
            if (customer == null)
            {
                return NotFound(new ApiException(404));
            }

            await customerService.UpdateCustomerAsync(id, customer);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return BadRequest(new ApiResponse(400, false, $"The ID {id} is not Exists"));
            }

            await customerService.DeleteCustomerAsync(id);
            return Ok(new ApiResponse(200, true, "Customer Deleted Successfully"));
        }
    }
}
