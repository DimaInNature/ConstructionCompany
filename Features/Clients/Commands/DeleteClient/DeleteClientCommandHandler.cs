namespace Features.Clients.Commands;

public class DeleteClientCommandHandler
    : IRequestHandler<DeleteClientCommand>
{
    private readonly ApplicationContext _context;

    public DeleteClientCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken token)
    {
        var entity = await _context.Clients.FindAsync(
             keyValues: new object[] { request.Id },
             cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Clients.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}