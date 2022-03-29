namespace Features.Products.Commands;

public class CreateProductCommand : IRequest
{
    public Product? Product { get; set; }

    public CreateProductCommand(Product product) => Product = product;

    public CreateProductCommand() { }
}