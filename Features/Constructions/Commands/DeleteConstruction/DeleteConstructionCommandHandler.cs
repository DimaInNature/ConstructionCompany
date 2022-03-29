namespace Features.Constructions.Commands;

public class DeleteConstructionCommandHandler
    : IRequestHandler<DeleteConstructionCommand>
{
    private readonly ApplicationContext _context;

    public DeleteConstructionCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteConstructionCommand request, CancellationToken token)
    {
        var entity = await _context.Constructions.FindAsync(
             keyValues: new object[] { request.Id },
             cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Constructions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}