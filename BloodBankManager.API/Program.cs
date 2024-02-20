using BloodBankManager.API.Middlewares;
using BloodBankManager.Application.Commands.CreateDonation;
using BloodBankManager.Application.Services;
using BloodBankManager.Application.Validators;
using BloodBankManager.Core.Repositories;
using BloodBankManager.Core.Services;
using BloodBankManager.Infrastructure.Persistence;
using BloodBankManager.Infrastructure.Persistence.Repositories;
using BloodBankManager.Infrastructure.Persistence.SeedData;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<CreateDonationCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<BloodBankManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IBloodStorageRepository, BloodStorageRepository>();
builder.Services.AddScoped<IBloodStorageService, BloodStorageService>();
builder.Services.AddScoped<IDonorService, DonorService>();

builder.Services.AddControllers().
                 AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<CreateDonationCommand>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDbMigrationHelper();

app.UseMiddleware<GlobalExceptionHandler>();

app.Run();
