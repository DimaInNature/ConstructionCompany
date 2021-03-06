namespace Presentation.ViewModels.UserControls.Users;

internal class DeleteUsersViewModel
    : BaseDeleteViewModel<User>, IDeleteUsersViewModel
{
    private readonly IUserFacadeService _userService;
    private readonly UserSessionService _sessionService;

    public DeleteUsersViewModel(IUserFacadeService userService,
        UserSessionService sessionService)
    {
        _userService = userService;

        _sessionService = sessionService;

        InitializeCommands();

        Task.Run(InitializeData);
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedItem is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedItem is null) return;

        if (SelectedItem.Login == _sessionService?.ActiveUser?.Login)
        {
            MessageBox.Show(
                messageBoxText: "Невозможно удалить пользователя этой сессии",
                caption: "Ошибка удаления",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        await _userService.DeleteAsync(SelectedItem.Id);

        MessageBox.Show(
           messageBoxText: "Удаление произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _lastItemId = null;
    }

    private async Task InitializeData()
    {
        Items = await _userService.GetUserListAsync();
    }

    #endregion
}