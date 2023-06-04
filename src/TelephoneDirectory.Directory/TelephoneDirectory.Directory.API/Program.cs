using TelephoneDirectory.Directory.DTO.Dto.Customer;
using TelephoneDirectory.Directory.DTO.Dto.Transaction;
using TelephoneDirectory.Directory.Service.Services;
using TelephoneDirectory.Directory.Service.Services.Interfaces;
using TelephoneDirectory.Framework.Repository.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.MongoRepositoryInit(builder.Configuration);
builder.Services.AddScoped<IDirectoryService, DirectoryService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(typeof(DirectoryProfile));
builder.Services.AddAutoMapper(typeof(ContactProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
