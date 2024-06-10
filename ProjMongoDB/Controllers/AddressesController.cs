using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDB.Models;
using ProjMongoDBAPI.Models;
using ProjMongoDBAPI.Services;

namespace ProjMongoDBAPI.Controllers
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
        public ActionResult<List<Address>> GetAll()
        {
            return _addressService.GetAll();
        }
        
        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            return _addressService.Get(id);
        }
        
        [HttpGet("{id:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffice(string cep)
        {
            return PostOfficeServices.GetAddress(cep).Result;
        }
        
        [HttpPost]
        public ActionResult<Address> Post(Address address)
        {
            _addressService.Create(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id }, address );
        }
    }

}
