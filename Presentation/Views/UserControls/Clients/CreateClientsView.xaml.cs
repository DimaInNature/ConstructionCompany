namespace Presentation.Views.UserControls.Clients;

public partial class CreateClientsView : UserControl
{
    private readonly ICreateClientsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateClientsViewModel>();

    public CreateClientsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}