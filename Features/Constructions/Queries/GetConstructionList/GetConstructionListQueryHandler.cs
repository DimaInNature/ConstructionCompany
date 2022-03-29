namespace Features.Constructions.Queries;

public class GetConstructionListQueryHandler
    : IRequestHandler<GetConstructionListQuery, List<Construction>?>
{
    private readonly ApplicationContext _context;

    public GetConstructionListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<Construction>?> Handle(GetConstructionListQuery request, CancellationToken token) =>
        await _context.Constructions.ToListAsync(token);
}