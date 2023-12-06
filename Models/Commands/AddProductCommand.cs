using MediatR;

namespace Models.Commands;

//Commands don't return anything
public record AddProductCommand(Product Product) : IRequest;