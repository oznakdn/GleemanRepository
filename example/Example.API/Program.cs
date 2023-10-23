using Example.API.Data;
using Example.API.Data.Context;
using Gleeman.Repository.MongoDriver;
using Microsoft.EntityFrameworkCore;
using Gleeman.Repository.MongoDriver.Configuration;
using Example.API.Repositories.Commands.MongoDriver;
using Example.API.Repositories.Queries.MongoDriver;
using Example.API.Repositories.Commands.EFCore;
using Example.API.Repositories.Queries.EFCore;
using Gleeman.Repository.Dapper.Configuration;
using Example.API.Repositories.Commands.Dapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TestDB"));
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddScoped<IEmployeeCommandRepository,EmployeeCommandRepository>();

//builder.Services.AddMongoRepository(builder.Configuration);
builder.Services.AddMongoRepository(option =>
{
    option.DatabaseName = "TestDB";
    option.ConnectionString = "mongodb://localhost:27017";
});

builder.Services.AddDapperRepository(option =>
{
    option.ConnectionString = "Server=(localdb)/MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;";
});


var app = builder.Build();

InMemoryData.AddData(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
