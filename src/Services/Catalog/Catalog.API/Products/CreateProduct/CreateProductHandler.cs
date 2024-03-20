using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : IRequest<CreatProductResult>;
public record CreatProductResult(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatProductResult>
{
    public Task<CreatProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Business logic Created Product
        throw new NotImplementedException();
    }
}
