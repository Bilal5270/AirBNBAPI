// Bilal Yousef S1169284


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AirBNBAPI.Data;
using AirBNBAPI.Services;
using AirBNBAPI.Repositories;
using System.Text.Json.Serialization;
using System.Reflection;
using AirBNBAPI.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AirBNBAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AirBNBAPIContext") ?? throw new InvalidOperationException("Connection string 'AirBNBAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISearchService, SearchService>();
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
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddVersionedApiExplorer(setup =>
{
    //setup.GroupNameFormat = ''
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.ApiVersion.ToString()
                );
        }
    });
    app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());
}



app.UseHttpsRedirection();
 
app.UseAuthorization();

app.MapControllers();

app.Run();
