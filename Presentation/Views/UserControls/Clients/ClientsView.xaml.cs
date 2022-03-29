namespace Presentation.Views.UserControls.Clients;

public partial class ClientsView : UserControl
{
    private readonly IClientsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IClientsViewModel>();

    public ClientsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}