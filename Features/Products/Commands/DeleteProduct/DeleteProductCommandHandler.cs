namespace Features.Products.Commands;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly ApplicationContext _context;

    public DeleteProductCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken token)
    {
        var entity = await _context.Products.FindAsync(
             keyValues: new object[] { request.Id },
             cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Products.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}