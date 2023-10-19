using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.API.Dtos;

public class ProductDto
{
    public string DisplayName { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}