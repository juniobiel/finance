using FinanceApp.Budget.API.Configuration;
using FinanceApp.Services.Core.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration("Budget");
builder.Services.RegisterServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(builder.Environment);

app.Run();
