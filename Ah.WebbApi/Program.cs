using Ah.Business.Implementation;
using Ah.Business.Interface;
using Ah.DataAccess.EF.Repositoryies;
using Ah.DataAccess.Interfaces;
using System.Net.Http.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Ah.Business.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductBs, ProductBs>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeBs, EmployeeBs>();

builder.Services.AddControllersWithViews().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);//ayný zamanda DI yapmamýzý saðlýyor


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
public class MyTransparentJsonNamingPolicy : JsonNamingPolicy
{
    // You can came up any custom transformation here, so instead just transparently
    // pass through the original C# class property name, it is possible to explicit
    // convert to PascalCase, etc:
    public override string ConvertName(string name)
    {
        var camelCase = name.Substring(0, 1).ToLowerInvariant();
        camelCase = camelCase + name.Substring(1, name.Length - 1);
        return camelCase;
    }
}
