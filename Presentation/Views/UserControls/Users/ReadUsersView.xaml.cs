namespace Presentation.Views.UserControls.Users;

public partial class ReadUsersView : UserControl
{
    private readonly IReadUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadUsersViewModel>();

    public ReadUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}