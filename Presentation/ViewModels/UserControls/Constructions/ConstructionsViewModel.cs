namespace Presentation.ViewModels.UserControls.Constructions;

internal class ConstructionsViewModel
    : BaseMenuViewModel, IConstructionsViewModel
{
    public ConstructionsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadConstructionsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadConstructionsView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateConstructionsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteConstructionsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadConstructionsView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateConstructionsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteConstructionsView;

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