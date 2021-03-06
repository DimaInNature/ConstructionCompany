namespace Presentation.Views.UserControls.Users;

public partial class CreateUsersView : UserControl
{
    private readonly ICreateUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateUsersViewModel>();

    public CreateUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        string[] roleNames = Enum.GetNames(typeof(UserRole));

        (RoleListComboBox.ItemsSource, RoleListComboBox.SelectedIndex) = (roleNames, 0);
    }
}