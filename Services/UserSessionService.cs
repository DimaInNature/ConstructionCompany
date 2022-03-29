namespace Services;

public class UserSessionService
{
    public User? ActiveUser
    {
        get => _activeUser;
        private set => _activeUser = value is null
            ? throw new ArgumentNullException("ActiveUser is null")
            : value;
    }

    public bool IsActive { get; private set; } = false;

    private User? _activeUser;

    private readonly IUserFacadeService _userService;

    public UserSessionService(IUserFacadeService userService) =>
        _userService = userService;

    public async Task StartSession(User activeUser)
    {
        if (IsActive) return;

        var user = await _userService.GetUserAsync(
            login: activeUser.Login,
            password: activeUser.Password);

        if (user is null)
            throw new ArgumentNullException("ActiveUser is null");

        ActiveUser = user;

        IsActive = true;
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = null;

        IsActive = false;
    }
}