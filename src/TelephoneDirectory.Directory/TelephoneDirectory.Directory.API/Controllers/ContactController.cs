using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.RequestModels;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.ResponseModels;
using TelephoneDirectory.Directory.DTO.Models.Results;
using TelephoneDirectory.Directory.Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectory.Directory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactRequestModel model)
        {
            var response = new ResponseModel<ContactResponseModel>();
            var result = await _contactService.AddAsync<ContactRequestModel, ContactResponseModel>(model);
            response.Data = result;

            return CreatedAtAction("GetById", new { id = result.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ContactRequestModel model)
        {
            var response = new ResponseModel<ContactResponseModel>();
            var result = await _contactService.UpdateAsync<ContactRequestModel, ContactResponseModel>(id, model);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new ResponseModel<ContactResponseModel>();
            var result = await _contactService.GetByIdAsync<ContactResponseModel>(id);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ResponseModel<IEnumerable<ContactResponseModel>>();
            var result = await _contactService.GetAllAsync<ContactResponseModel>();
            response.Data = result;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contactService.DeleteAsync(id);
            return Ok(new ResponseModel(true));
        }
    }
}
