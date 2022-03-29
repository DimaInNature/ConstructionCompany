namespace Features.Users.Queries;

public class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    private readonly ApplicationContext _context;

    public GetUserByLoginAndPasswordQueryHandler(ApplicationContext context) => _context = context;

    public async Task<User?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token) =>
        await _context.Users.FirstOrDefaultAsync(
            predicate: user => user.Login == request.Login &&
            user.Password == request.Password,
            cancellationToken: token);
}