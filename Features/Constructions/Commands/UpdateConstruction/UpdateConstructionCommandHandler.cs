namespace Features.Constructions.Commands;

public class UpdateConstructionCommandHandler
    : IRequestHandler<UpdateConstructionCommand>
{
    private readonly ApplicationContext _context;

    public UpdateConstructionCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateConstructionCommand request, CancellationToken token)
    {
        if (request.Construction is null) return Unit.Value;

        var entity = await _context.Constructions.FindAsync(
            keyValues: new object[] { request.Construction.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.Construction.Id;
        entity.Name = request.Construction.Name;
        entity.Status = request.Construction.Status;
        entity.EndDate = request.Construction.EndDate;
        entity.Address = request.Construction.Address;
        entity.ClientId = request.Construction.ClientId;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}