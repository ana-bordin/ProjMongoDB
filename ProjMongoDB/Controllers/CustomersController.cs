using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDB.Models;
using ProjMongoDBAPI.Services;

namespace ProjMongoDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customersService;
        private readonly AddressService _addressService;
        public CustomersController(CustomerService customerService, AddressService addressService)
        {
            _customersService = customerService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll() => _customersService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetCustomerById")]
        public ActionResult<Customer> GetById (string id)
        {
            var customer = _customersService.Get(id);
            if (id == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            Address address = _addressService.Create(customer.Address);
            customer.Address = address;
            var c = _customersService.Create(customer);
            if (c == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetCustomerById", new {id = c.Id }, c);
        }
    }
}
