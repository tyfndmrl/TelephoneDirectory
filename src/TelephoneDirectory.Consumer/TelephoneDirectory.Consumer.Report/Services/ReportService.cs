using Microsoft.Extensions.Options;
using RestSharp;
using TelephoneDirectory.Consumer.Report.Models.Configurations.ServiceUrl;
using TelephoneDirectory.Consumer.Report.Models.Directory.RequestModels;
using TelephoneDirectory.Consumer.Report.Models.Directory.ResponseModels;
using TelephoneDirectory.Consumer.Report.Models.Report;
using TelephoneDirectory.Consumer.Report.Services.Interfaces;

namespace TelephoneDirectory.Consumer.Report.Services
{
    public class ReportService : IReportService
    {
        private RestClient _client;
        private readonly Dictionary<string, string> _headers;
        private readonly DirectoryConfiguration _directoryConfiguration;
        private readonly ReportConfiguration _reportConfiguration;
        public ReportService(IOptions<DirectoryConfiguration> directoryConfiguration, IOptions<ReportConfiguration> reportConfiguration)
        {
            _directoryConfiguration = directoryConfiguration.Value;
            _reportConfiguration = reportConfiguration.Value;
            _headers = new Dictionary<string, string>
            {
                { "Content-type", "application/json" }
            };
        }

        public async Task DirectoryLocationReport(DirectoryLocationReportConsumerModel model)
        {
            var restDirectoryRequest = PrepareRestRequest(_directoryConfiguration.BaseUrl, _directoryConfiguration.DirectoryLocationReportUrl);
            var resultDirectory = await _client.ExecuteAsync<object>(restDirectoryRequest);

            var requestModel = new ReportRequestModel { Status = Models.Directory.Enums.ReportStatusEnum.Completed };
            var restReportRequest = PrepareRestRequest(_reportConfiguration.BaseUrl, string.Format(_reportConfiguration.UpdateUrl, model.Id), Method.Put, requestModel);
            var result = await _client.ExecuteAsync<ReportResponseModel>(restReportRequest);
        }

        private RestRequest PrepareRestRequest<TRequest>(string baseUrl, string resource, Method method, TRequest? requestModel)
        {
            _client = new RestClient(baseUrl);
            var restRequest = new RestRequest(resource, method);
            restRequest.AddHeaders(_headers);
            if (requestModel != null)
                restRequest.AddBody(requestModel);

            return restRequest;
        }

        private RestRequest PrepareRestRequest(string baseUrl, string resource)
        {
            _client = new RestClient(baseUrl);
            var restRequest = new RestRequest(resource, Method.Get);
            restRequest.AddHeaders(_headers);

            return restRequest;
        }
    }
}
