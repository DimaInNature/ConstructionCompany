namespace Presentation.Views.UserControls.Users;

public partial class DeleteUsersView : UserControl
{
    private readonly IDeleteUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteUsersViewModel>();

    public DeleteUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}