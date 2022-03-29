namespace Features.Workers.Queries;

public class GetWorkerListQueryHandler
    : IRequestHandler<GetWorkerListQuery, List<Worker>?>
{
    private readonly ApplicationContext _context;

    public GetWorkerListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<Worker>?> Handle(GetWorkerListQuery request, CancellationToken token) =>
        await _context.Workers.ToListAsync(token);
}