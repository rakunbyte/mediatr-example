using Models;

namespace Databases;

public class ProductStore
{
    private List<Product> Products = new()
    {
        new Product {Id = 1, Name = "Product 1"},
        new Product {Id = 2, Name = "Product 2"},
        new Product {Id = 3, Name = "Product 3"}
    };

    public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(Products);

    public async Task AddProduct(Product product) => Products.Add(product);
}