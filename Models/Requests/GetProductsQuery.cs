using MediatR;

namespace Models.Requests;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
