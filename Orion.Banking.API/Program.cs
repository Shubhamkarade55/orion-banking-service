using Microsoft.EntityFrameworkCore;
using Orion.Banking.Application.Interfaces;
using Orion.Banking.Application.Services;
using Orion.Banking.Infrastructure.Data;
using Orion.Banking.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Orion Banking API",
        Version = "v1"
    });
});

// EF Core
builder.Services.AddDbContext<BankingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

// Enable Swagger UI for debugging (remove or guard with env check for production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orion Banking API v1");
    c.RoutePrefix = string.Empty; // Serve UI at the app root: https://localhost:7148/
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();