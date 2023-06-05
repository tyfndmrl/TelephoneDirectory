using AutoMapper;
using TelephoneDirectory.Report.DTO.Dto.Report.ConsumerModels;
using TelephoneDirectory.Report.DTO.Dto.Report.RequestModels;
using TelephoneDirectory.Report.DTO.Dto.Report.ResponseModels;

namespace TelephoneDirectory.Report.DTO.Dto.Report
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportRequestModel, DDD.Entities.ReportEntity>();
            CreateMap<DDD.Entities.ReportEntity, ReportResponseModel>();
            CreateMap<ReportResponseModel, DirectoryLocationReportConsumerModel>();
        }
    }
}
