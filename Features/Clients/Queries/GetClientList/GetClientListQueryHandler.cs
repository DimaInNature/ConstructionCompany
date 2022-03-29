namespace Features.Clients.Queries;

public class GetClientListQueryHandler
    : IRequestHandler<GetClientListQuery, List<Client>?>
{
    private readonly ApplicationContext _context;

    public GetClientListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<Client>?> Handle(GetClientListQuery request, CancellationToken token) =>
        await _context.Clients.ToListAsync(cancellationToken: token);
}