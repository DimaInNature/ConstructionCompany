namespace Presentation.ViewModels.UserControls.Clients;

internal class ClientsViewModel
    : BaseMenuViewModel, IClientsViewModel
{
    public ClientsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadClientsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadClientsView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateClientsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteClientsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadClientsView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateClientsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteClientsView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowCreatePageCommand = new RelayCommand(executeAction: ExecuteShowCreatePage,
           canExecuteFunc: CanExecuteShowCreatePage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}