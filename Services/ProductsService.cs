using Databases;
using MediatR;
using Models;
using Models.Commands;
using Models.Requests;

namespace Services;

public class ProductsService(ProductStore productStore) : 
    IRequestHandler<GetProductsQuery, IEnumerable<Product>>, 
    IRequestHandler<AddProductCommand> 
{
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => 
        await productStore.GetAllProducts();
    
    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken) => 
        await productStore.AddProduct(request.Product);
}