using TelephoneDirectory.Consumer.Report.Consumers;
using TelephoneDirectory.Consumer.Report.Consumers.Interfaces;
using TelephoneDirectory.Framework.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.RabbitMQManagerInit(builder.Configuration);
builder.Services.AddScoped<IReportTrackerConsumer, ReportTrackerConsumer>();

var app = builder.Build();

app.MapControllers();
app.Run();
