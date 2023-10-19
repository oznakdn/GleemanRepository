namespace Example.API.Models;

public class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public ICollection<Product> Products { get; set; }
}
