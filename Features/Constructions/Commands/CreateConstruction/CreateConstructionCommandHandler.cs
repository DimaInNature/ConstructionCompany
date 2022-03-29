namespace Features.Constructions.Commands;

public class CreateConstructionCommandHandler
    : IRequestHandler<CreateConstructionCommand>
{
    private readonly ApplicationContext _context;

    public CreateConstructionCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateConstructionCommand request, CancellationToken token)
    {
        if (request.Construction is null) return Unit.Value;

        await _context.Constructions.AddAsync(entity: request.Construction, cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}