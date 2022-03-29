namespace Features.Clients.Commands;

public class CreateClientCommandHandler
    : IRequestHandler<CreateClientCommand>
{
    private readonly ApplicationContext _context;

    public CreateClientCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateClientCommand request, CancellationToken token)
    {
        if (request.Client is null) return Unit.Value;

        await _context.Clients.AddAsync(entity: request.Client, cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}