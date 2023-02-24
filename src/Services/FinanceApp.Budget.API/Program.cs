using FinanceApp.Budget.API.Configuration;
using FinanceApp.Services.Core.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration("Budget");

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(builder.Environment);

app.Run();
