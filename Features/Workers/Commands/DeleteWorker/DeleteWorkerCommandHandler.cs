namespace Features.Workers.Commands;

public class DeleteWorkerCommandHandler
    : IRequestHandler<DeleteWorkerCommand>
{
    private readonly ApplicationContext _context;

    public DeleteWorkerCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteWorkerCommand request, CancellationToken token)
    {
        var entity = await _context.Workers.FindAsync(
             keyValues: new object[] { request.Id },
             cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Workers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}