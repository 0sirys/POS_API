using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShopApi;
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.DTOs.ProductDTOs;
using ShopApi.DTOs.UserDTOs;
using ShopApi.Generators;
using ShopApi.Interface;
using ShopApi.Models;
using ShopApi.Repository;
using ShopApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Add repositories
builder.Services.AddScoped<ICRUD<Product, long>, ProductRepository>();
builder.Services.AddScoped<ICRUD<User, string>, UserRepository>();
builder.Services.AddScoped<ICRUD<Invoice, long>, InvoiceRepository>();

//Add Excel Generator
builder.Services.AddScoped<IGenerator, GenToExcel>();
//Add Services
builder.Services.AddScoped<IService<UserDTO, string>, UserService>();
builder.Services.AddScoped<IService<ProductDTO, long>, ProductServices>();
builder.Services.AddScoped<IService<InvoiceDTO, long>, InvoiceService>();
//Add Validator
builder.Services.AddScoped<IValidator<UserDTO>, UserValidator>();

//Add DBcontext to the container
builder.Services.AddDbContext<ShopContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Link")));
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
public partial class Program { }
