using FluentValidation.AspNetCore;
using FluentValidation;
using HotelReservation.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Application.Validations.CustomerDtoValidations;
using HotelReservation.Persistence.Registration;

var builder = WebApplication.CreateBuilder(args);
//CustomerCreateDtoValidator

// Add services to the container.
builder.Services.AddControllers();

// ✅ FluentValidation qeydiyyatı
builder.Services.AddValidatorsFromAssembly(typeof(CustomerCreateDtoValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters(); 

// Add DbContext
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

//  Repositories və Services
builder.Services.RegisterServices();

// Add swagger (optional, for API testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
