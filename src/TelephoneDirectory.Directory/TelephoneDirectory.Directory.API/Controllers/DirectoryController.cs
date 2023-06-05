using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Directory.DTO.Dto.Customer.RequestModels;
using TelephoneDirectory.Directory.DTO.Dto.Customer.ResponseModels;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.RequestModels;
using TelephoneDirectory.Directory.DTO.Dto.Transaction.ResponseModels;
using TelephoneDirectory.Directory.DTO.Models.Results;
using TelephoneDirectory.Directory.Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectory.Directory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;
        private readonly IContactService _contactService;
        public DirectoryController(IDirectoryService DirectoryService, IContactService contactService)
        {
            _directoryService = DirectoryService;
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> DirectoryPost(DirectoryRequestModel model)
        {
            var response = new ResponseModel<DirectoryResponseModel>();
            var result = await _directoryService.AddAsync<DirectoryRequestModel, DirectoryResponseModel>(model);
            response.Data = result;

            return CreatedAtAction("DirectoryGetById", new { id = result.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DirectoryPut(Guid id, DirectoryRequestModel model)
        {
            var response = new ResponseModel<DirectoryResponseModel>();
            var result = await _directoryService.UpdateAsync<DirectoryRequestModel, DirectoryResponseModel>(id, model);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DirectoryGetById(Guid id)
        {
            var response = new ResponseModel<DirectoryResponseModel>();
            var result = await _directoryService.GetByIdAsync<DirectoryResponseModel>(id);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> DirectoryGetAll()
        {
            var response = new ResponseModel<IEnumerable<DirectoryResponseModel>>();
            var result = await _directoryService.GetAllAsync<DirectoryResponseModel>();
            response.Data = result;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DirectoryDelete(Guid id)
        {
            await _directoryService.DeleteAsync(id);
            return Ok(new ResponseModel(true));
        }

        [HttpGet("DirectoryLocationReport")]
        public async Task<IActionResult> DirectoryLocationReport()
        {
            //Todo: Report service and response service . . .
            return Ok();
        }

        //[HttpPost("{directoryId}/Contact")]
        //public async Task<IActionResult> ContactPost(Guid directoryId, ContactRequestModel model)
        //{
        //    var response = new ResponseModel<ContactResponseModel>();
        //    var result = await _contactService.AddAsync<ContactRequestModel, ContactResponseModel>(model);
        //    response.Data = result;

        //    return CreatedAtAction("ContactGetById", new { directoryId, contactId = result.Id }, response);
        //}

        //[HttpPut("{directoryId}/Contact/{contactId}")]
        //public async Task<IActionResult> ContactPut(Guid directoryId, Guid contactId, ContactRequestModel model)
        //{
        //    var response = new ResponseModel<ContactResponseModel>();
        //    var result = await _contactService.UpdateAsync<ContactRequestModel, ContactResponseModel>(contactId, model);
        //    response.Data = result;
        //    return Ok(response);
        //}

        //[HttpGet("{directoryId}/Contact/{contactId}")]
        //public async Task<IActionResult> ContactGetById(Guid directoryId, Guid contactId)
        //{
        //    var response = new ResponseModel<ContactResponseModel>();
        //    var result = await _contactService.GetByIdAsync<ContactResponseModel>(contactId);
        //    response.Data = result;
        //    return Ok(response);
        //}

        //[HttpGet("{directoryId}/Contact")]
        //public async Task<IActionResult> ContactGetAll()
        //{
        //    var response = new ResponseModel<IEnumerable<ContactResponseModel>>();
        //    var result = await _contactService.GetAllAsync<ContactResponseModel>();
        //    response.Data = result;
        //    return Ok(response);
        //}

        //[HttpDelete("{directoryId}/Contact/{contactId}")]
        //public async Task<IActionResult> ContactDelete(Guid directoryId, Guid contactId)
        //{
        //    await _contactService.DeleteAsync(contactId);
        //    return Ok(new ResponseModel(true));
        //}
    }
}
