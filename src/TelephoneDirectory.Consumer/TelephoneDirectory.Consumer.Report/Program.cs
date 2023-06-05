using TelephoneDirectory.Consumer.Report.Consumers;
using TelephoneDirectory.Consumer.Report.Consumers.Interfaces;
using TelephoneDirectory.Consumer.Report.Models.Configurations.ServiceUrl;
using TelephoneDirectory.Consumer.Report.Services;
using TelephoneDirectory.Consumer.Report.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.RabbitMQManagerInit(builder.Configuration);
builder.Services.AddScoped<IReportTrackerConsumer, ReportTrackerConsumer>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.Configure<DirectoryConfiguration>(builder.Configuration.GetSection("ServiceUrl:Directory"));
builder.Services.Configure<ReportConfiguration>(builder.Configuration.GetSection("ServiceUrl:Report"));

var app = builder.Build();

app.MapControllers();
app.Run();
