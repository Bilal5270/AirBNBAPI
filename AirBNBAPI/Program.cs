// Bilal Yousef S1169284


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AirBNBAPI.Data;
using AirBNBAPI.Services;
using AirBNBAPI.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AirBNBAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AirBNBAPIContext") ?? throw new InvalidOperationException("Connection string 'AirBNBAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerDatabaseService>();
builder.Services.AddScoped<ILandlordService, LandlordDatabaseService>();
builder.Services.AddScoped<IReservationService, ReservationDatabaseService>();
builder.Services.AddScoped<ILocationService, LocationDatabaseService>();
builder.Services.AddScoped<IAirBnBRepository, AirBnBRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
