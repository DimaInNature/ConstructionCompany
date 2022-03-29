namespace Features.Products.Commands;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }

    public DeleteProductCommand(int id) => Id = id;

    public DeleteProductCommand() { }
}