namespace Presentation.ViewModels.UserControls.Users;

internal class ReadUsersViewModel
    : BaseReadViewModel<User>, IReadUsersViewModel
{
    private readonly IUserFacadeService _userService;

    public ReadUsersViewModel(IUserFacadeService userService)
    {
        _userService = userService;

        Task.Run(InitializeData);
    }

    private async Task InitializeData()
    {
        Items = await _userService.GetUserListAsync();
    }
}