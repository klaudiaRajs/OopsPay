using Contracts.Products;

namespace Products.Repos;

public class GetProductDetailsRepo
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Laptop Dell XPS 13",
            InStock = 15,
            Price = 4999.99f
        },
        new Product
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Monitor LG UltraWide 34\"",
            InStock = 8,
            Price = 2199.50f
        },
        new Product
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Klawiatura mechaniczna Keychron K8",
            InStock = 42,
            Price = 459.90f
        },
        new Product
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "Mysz Logitech MX Master 3S",
            InStock = 60,
            Price = 349.90f
        },
        new Product
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "Słuchawki Sony WH-1000XM5",
            InStock = 23,
            Price = 1799.00f
        }
    };
    public List<Product> Get(GetProductDetails request)
    {
        var payload = GetProductDetailsRequest.FromPayload(request.Payload);
        if( payload.ProductIds.Count == 0)
        {
            return new List<Product>();
        }

        return _products.Where(a => payload.ProductIds.Contains(a.Id)).ToList(); 
    }
}