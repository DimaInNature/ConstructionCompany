namespace Features.Products.Commands;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand>
{
    private readonly ApplicationContext _context;

    public CreateProductCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken token)
    {
        if (request.Product is null) return Unit.Value;

        await _context.Products.AddAsync(entity: request.Product, cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}