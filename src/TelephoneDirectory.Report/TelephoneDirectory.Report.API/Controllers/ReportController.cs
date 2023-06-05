using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Report.DTO.Dto.Report.RequestModels;
using TelephoneDirectory.Report.DTO.Dto.Report.ResponseModels;
using TelephoneDirectory.Report.DTO.Models.Results;
using TelephoneDirectory.Report.Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectory.Directory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReportRequestModel model)
        {
            var response = new ResponseModel<ReportResponseModel>();
            var result = await _reportService.AddAsync<ReportRequestModel, ReportResponseModel>(model);
            response.Data = result;
            return CreatedAtAction("GetById", new { id = result.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ReportRequestModel model)
        {
            var response = new ResponseModel<ReportResponseModel>();
            var result = await _reportService.UpdateAsync<ReportRequestModel, ReportResponseModel>(id, model);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new ResponseModel<ReportResponseModel>();
            var result = await _reportService.GetByIdAsync<ReportResponseModel>(id);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ResponseModel<IEnumerable<ReportResponseModel>>();
            var result = await _reportService.GetAllAsync<ReportResponseModel>();
            response.Data = result;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reportService.DeleteAsync(id);
            return Ok(new ResponseModel(true));
        }
    }
}
