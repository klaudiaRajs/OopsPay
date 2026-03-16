using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Products;

[Table("Products", Schema = "Product")]
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int InStock { get; set; }
    public float Price { get; set; }
}