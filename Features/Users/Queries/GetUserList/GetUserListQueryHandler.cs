namespace Features.Users.Queries;

public class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, List<User>?>
{
    private readonly ApplicationContext _context;

    public GetUserListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<User>?> Handle(GetUserListQuery request, CancellationToken token) =>
        await _context.Users.ToListAsync(cancellationToken: token);
}