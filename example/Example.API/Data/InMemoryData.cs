using Example.API.Data.Context;
using Example.API.Models;

namespace Example.API.Data;

public class InMemoryData
{
    public static void AddData(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<AppDbContext>();

        db.Categories.Add(new Category
        {
            Id = 1,
            DisplayName = "Category1"
        });
        db.SaveChanges();


        db.Products.AddRange(
        new Product
        {
            Id = 1,
            DisplayName = "Product1",
            Price = 100,
            CategoryId = 1,
            Category = db.Categories.Single()
        },
         new Product
         {
             Id = 2,
             DisplayName = "Product2",
             Price = 200,
             CategoryId = 1,
             Category = db.Categories.Single()

         },
          new Product
          {
              Id = 3,
              DisplayName = "Product3",
              Price = 300,
              CategoryId = 1,
              Category = db.Categories.Single()
          }
        );


        db.SaveChanges();
    }
}
