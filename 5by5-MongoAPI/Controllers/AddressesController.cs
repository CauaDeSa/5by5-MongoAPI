using _5by5_MongoAPI.Models;
using _5by5_MongoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _5by5_MongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id) => _addressService.Get(id);

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }
    }
}