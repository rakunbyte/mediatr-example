using Models;

namespace Databases;

public class ProductStore
{
    private List<Product> Products = new()
    {
        new Product {Name = "Fan"},
        new Product {Name = "Baseball Bat"},
        new Product {Name = "Ice Cream Cone"},
        new Product {Name = "Soda"}
    };

    public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(Products);

    public async Task AddProduct(Product product) => Products.Add(product);

    public async Task<Product?> GetProductById(long id) => Products.FirstOrDefault(x => x.Id == id);
    
    public async Task EventOccured(Product product, string evt)
    {
        Products.First(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
        await Task.CompletedTask;
    }
}