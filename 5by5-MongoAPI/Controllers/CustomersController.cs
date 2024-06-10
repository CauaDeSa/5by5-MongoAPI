using _5by5_MongoAPI.Models;
using _5by5_MongoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5by5_MongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;

        public CustomersController(CustomerService customerService, AddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomerById")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Address = _addressService.Get(customer.Address.Id);

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            customer.Address = _addressService.Post(customer.Address);

            var c = _customerService.Post(customer);

            if (c == null) 
                return BadRequest();


            return CreatedAtRoute("GetCustomerById", new { id = customer.Id.ToString() }, customer);
        }
    }
}