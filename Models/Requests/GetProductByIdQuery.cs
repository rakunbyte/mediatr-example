using MediatR;

namespace Models.Requests;

public record GetProductByIdQuery(long Id) : IRequest<Product?>;