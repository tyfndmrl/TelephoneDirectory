using AutoMapper;
using TelephoneDirectory.Report.DDD.Entities;
using TelephoneDirectory.Report.Service.Services.Bases;
using TelephoneDirectory.Report.Service.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Report.Service.Services
{
    public class ReportService : Service<IRepository<ReportEntity>, ReportEntity>, IReportService
    {
        public ReportService(IRepository<ReportEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
