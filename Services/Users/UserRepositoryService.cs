namespace Services.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IMediator _mediator;

    public UserRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<User>?> GetUserListAsync() =>
        await _mediator.Send(request: new GetUserListQuery());

    public async Task<User?> GetUserAsync(string login) =>
        await _mediator.Send(request: new GetUserByLoginQuery(login: login));

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(
            login: login, password: password));

    public async Task CreateAsync(User user) =>
         await _mediator.Send(request: new CreateUserCommand(user: user));

    public async Task UpdateAsync(User user) =>
        await _mediator.Send(request: new UpdateUserCommand(user: user));

    public async Task DeleteAsync(int userId) =>
        await _mediator.Send(request: new DeleteUserCommand(id: userId));
}