using MediatR;

namespace Models.Commands;

//Commands don't return anything
public record AddProductCommand(Product Product) : IRequest;

public record AddProductCommand2(Product Product) : IRequest<Product>;