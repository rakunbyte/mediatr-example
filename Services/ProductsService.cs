using Databases;
using MediatR;
using Models;
using Models.Commands;
using Models.Requests;

namespace Services;

public class ProductsService(ProductStore productStore) : 
    IRequestHandler<GetProductsQuery, IEnumerable<Product>>, 
    IRequestHandler<AddProductCommand>,
    IRequestHandler<GetProductByIdQuery, Product?>,
    IRequestHandler<AddProductCommand2, Product>
{
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => 
        await productStore.GetAllProducts();
    
    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken) => 
        await productStore.AddProduct(request.Product);
    
    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await productStore.GetProductById(request.Id);
    
    public async Task<Product> Handle(AddProductCommand2 request, CancellationToken cancellationToken)
    {
        await productStore.AddProduct(request.Product);
        return request.Product;
    }
}