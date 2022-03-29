namespace Services.Constructions;

public class ConstructionRepositoryService : IConstructionRepositoryService
{
    private readonly IMediator _mediator;

    public ConstructionRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Construction>?> GetConstructionListAsync() =>
        await _mediator.Send(request: new GetConstructionListQuery());

    public async Task CreateAsync(Construction construction) =>
        await _mediator.Send(request: new CreateConstructionCommand(construction: construction));

    public async Task UpdateAsync(Construction construction) =>
        await _mediator.Send(request: new UpdateConstructionCommand(construction: construction));

    public async Task DeleteAsync(int constructionId) =>
        await _mediator.Send(request: new DeleteConstructionCommand(id: constructionId));
}