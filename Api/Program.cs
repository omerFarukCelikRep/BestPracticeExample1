using Api.Extensions;
using Api.Service.Abstract;
using Api.Service.Concrete;
using Api.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(options => options.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddConfigureMapping();

builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();

builder.Services.AddHttpClient("garantiapi", config =>
{
    config.BaseAddress = new Uri("http://garanti.com");
    config.DefaultRequestHeaders.Add("Authorization", "Bearer 15634641634");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomHealthCheck();

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
