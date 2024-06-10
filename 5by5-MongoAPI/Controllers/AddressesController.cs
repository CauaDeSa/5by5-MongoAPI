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

        public AddressesController(AddressService addressService) => _addressService = addressService;

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id) => _addressService.Get(id);

        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffice(string cep)
        {
            var address = PostOfficeService.GetAddress(cep);

            if (address == null)
                return NotFound();

            return address.Result;
        }

        [HttpPost]
        public ActionResult<Address> Post(Address address)
        {
            _addressService.Post(address);

            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }
    }
}