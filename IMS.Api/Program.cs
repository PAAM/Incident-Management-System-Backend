using IMS.Core.Interfaces;
using IMS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();
builder.Services.AddTransient<IIncidentRepository, IncidentMongoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
