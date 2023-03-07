// Bilal Yousef S1169284


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AirBNBAPI.Data;
using AirBNBAPI.Services;
using AirBNBAPI.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AirBNBAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AirBNBAPIContext") ?? throw new InvalidOperationException("Connection string 'AirBNBAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerDatabaseService>();
builder.Services.AddScoped<ILandlordService, LandlordDatabaseService>();
builder.Services.AddScoped<IListingService, ReservationDatabaseService>();
builder.Services.AddScoped<ILocationService, LocationDatabaseService>();
builder.Services.AddScoped<IAirBnBRepository, AirBnBRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
