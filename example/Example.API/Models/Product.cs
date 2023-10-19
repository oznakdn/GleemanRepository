namespace Example.API.Models;

public class Product
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
