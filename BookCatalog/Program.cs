using BookCatalog.BusinessRules.Repositories;
using BookCatalog.BusinessRules.Services;
using BookCatalog.DataAccess.Interfaces;
using BookCatalog.DataAccess.Repositories;
using BookCatalog.Entities.Attributes;
using BookCatalog.Entities.Data;
using BookCatalog.Utilities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddDbContext<BookCatalogDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("BookCatalog")));

builder.Services.AddClassesWithAttributes<ServiceDependency>(Assembly.GetAssembly(typeof(Program)));

Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Hour)
        .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog();
});

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
