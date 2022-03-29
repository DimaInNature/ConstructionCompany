namespace Presentation.Views.UserControls.Clients;

public partial class ReadClientsView : UserControl
{
    private readonly IReadClientsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadClientsViewModel>();

    public ReadClientsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}