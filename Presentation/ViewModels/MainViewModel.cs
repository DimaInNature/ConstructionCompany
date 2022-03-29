namespace Presentation.ViewModels;

internal class MainViewModel
    : BaseViewModel, IMainViewModel
{
    #region Members

    #region Commands

    public ICommand? ShowHomePageCommand { get; private set; }

    public ICommand? ShowClientsPageCommand { get; private set; }

    public ICommand? ShowUsersPageCommand { get; private set; }

    public ICommand? ShowWorkersPageCommand { get; private set; }

    public ICommand? ShowProductsPageCommand { get; private set; }

    public ICommand? ShowConstructionsPageCommand { get; private set; }

    public ICommand? ShowReportsPageCommand { get; private set; }

    #endregion

    #region View

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;
            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));

            MenuIsVisible = value switch
            {
                null => Visibility.Visible,
                _ => Visibility.Collapsed,
            };
        }
    }

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;
            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    #endregion

    #region Private

    private Visibility _frameVisibility;

    private object? _frameSource;

    private Visibility _menuIsVisible;

    #endregion

    #endregion

    public MainViewModel()
    {
        InitializeCommands();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowClientsPage(object obj) =>
        FrameSource = new ClientsView();

    private void ExecuteShowHomePage(object obj) =>
        FrameSource = null;

    private void ExecuteShowWorkersPage(object obj) =>
        FrameSource = new WorkersView();

    private void ExecuteShowUsersPage(object obj) =>
        FrameSource = new UsersView();

    private void ExecuteShowProductsPage(object obj) =>
        FrameSource = new ProductsView();

    private void ExecuteShowConstructionsPage(object obj) =>
        FrameSource = new ConstructionsView();

    private void ExecuteShowReportsPage(object obj) =>
        FrameSource = new ReportsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowHomePage(object obj) =>
        !(FrameSource is null && MenuIsVisible is Visibility.Visible);

    private bool CanExecuteShowClientsPage(object obj) =>
        FrameSource is not ClientsView;

    private bool CanExecuteShowWorkersPage(object obj) =>
        FrameSource is not WorkersView;

    private bool CanExecuteShowUsersPage(object obj) =>
        FrameSource is not UsersView;

    private bool CanExecuteShowProductsPage(object obj) =>
        FrameSource is not ProductsView;

    private bool CanExecuteShowConstructionsPage(object obj) =>
        FrameSource is not ConstructionsView;

    private bool CanExecuteShowReportsPage(object obj) =>
        FrameSource is not ReportsView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowHomePageCommand = new RelayCommand(executeAction: ExecuteShowHomePage,
            canExecuteFunc: CanExecuteShowHomePage);

        ShowClientsPageCommand = new RelayCommand(executeAction: ExecuteShowClientsPage,
            canExecuteFunc: CanExecuteShowClientsPage);

        ShowUsersPageCommand = new RelayCommand(executeAction: ExecuteShowUsersPage,
           canExecuteFunc: CanExecuteShowUsersPage);

        ShowWorkersPageCommand = new RelayCommand(executeAction: ExecuteShowWorkersPage,
            canExecuteFunc: CanExecuteShowWorkersPage);

        ShowProductsPageCommand = new RelayCommand(executeAction: ExecuteShowProductsPage,
            canExecuteFunc: CanExecuteShowProductsPage);

        ShowConstructionsPageCommand = new RelayCommand(executeAction: ExecuteShowConstructionsPage,
            canExecuteFunc: CanExecuteShowConstructionsPage);

        ShowReportsPageCommand = new RelayCommand(executeAction: ExecuteShowReportsPage,
            canExecuteFunc: CanExecuteShowReportsPage);
    }

    #endregion
}