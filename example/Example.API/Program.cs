using Example.API.Data;
using Example.API.Data.Context;
using Example.API.Repositories.Commands;
using Example.API.Repositories.Queries;
using Gleeman.Repository.MongoDriver;
using Microsoft.EntityFrameworkCore;
using Gleeman.Repository.MongoDriver.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TestDB"));
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();

//builder.Services.AddMongoRepository(builder.Configuration);
builder.Services.AddMongoRepository(option =>
{
    option.DatabaseName = "TestDB";
    option.ConnectionString = "mongodb://localhost:27017";
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
