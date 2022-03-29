namespace Features.Users.Queries;

public class GetUserByLoginQueryHandler
    : IRequestHandler<GetUserByLoginQuery, User?>
{
    private readonly ApplicationContext _context;

    public GetUserByLoginQueryHandler(ApplicationContext context) => _context = context;

    public async Task<User?> Handle(GetUserByLoginQuery request, CancellationToken token) =>
        await _context.Users.FirstOrDefaultAsync(
            predicate: user => user.Login == request.Login,
            cancellationToken: token);
}