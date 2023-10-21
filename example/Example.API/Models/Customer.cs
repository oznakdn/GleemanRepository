using MongoDB.Bson;

namespace Example.API.Models;

public class Customer
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
