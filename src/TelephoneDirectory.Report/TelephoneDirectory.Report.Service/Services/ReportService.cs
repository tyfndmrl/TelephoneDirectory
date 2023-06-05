using AutoMapper;
using TelephoneDirectory.Report.DDD.Entities;
using TelephoneDirectory.Report.Service.Services.Bases;
using TelephoneDirectory.Report.Service.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;
using TelephoneDirectory.Framework.RabbitMQ.Publishers.Interfaces;
using TelephoneDirectory.Report.DTO.Dto.Report.ConsumerModels;

namespace TelephoneDirectory.Report.Service.Services
{
    public class ReportService : Service<IRepository<ReportEntity>, ReportEntity>, IReportService
    {
        private readonly IPublisher _publisher;
        public ReportService(IRepository<ReportEntity> repository, IMapper mapper, IPublisher publisher) : base(repository, mapper)
        {
            _publisher = publisher;
        }

        public override async Task<TResponseDto> AddAsync<TRequestDto, TResponseDto>(TRequestDto model)
        {
            var result = await base.AddAsync<TRequestDto, TResponseDto>(model);
            var consumerModel = _mapper.Map<DirectoryLocationReportConsumerModel>(result);
            await _publisher.SendAsync("report-tracker.directory-location-report.queue", consumerModel);

            return result;
        }
    }
}
