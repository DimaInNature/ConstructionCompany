namespace Presentation.ViewModels.UserControls.Workers;

internal class WorkersViewModel
    : BaseMenuViewModel, IWorkersViewModel
{
    public WorkersViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadWorkersView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadWorkersView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateWorkersView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteWorkersView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadWorkersView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateWorkersView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteWorkersView;

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