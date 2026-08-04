using IMS.Api.Configuration;
using IMS.Core.Authorization;
using IMS.Core.Interfaces;
using IMS.Core.Services;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<IMSDbContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.SectionName));

var jwtOptions = builder.Configuration
    .GetSection(JwtOptions.SectionName)
    .Get<JwtOptions>()!;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissions.RoleRead, policy =>
    {
        policy.RequireClaim("scope", Permissions.RoleRead);
    });
    options.AddPolicy(Permissions.RoleWrite, policy =>
    {
        policy.RequireClaim("scope", Permissions.RoleWrite);
    });
    options.AddPolicy(Permissions.RoleOwner, policy =>
    {
        policy.RequireClaim("scope", Permissions.RoleOwner);
    });
});



//builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();
//builder.Services.AddTransient<IIncidentRepository, IncidentMongoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline. 

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
