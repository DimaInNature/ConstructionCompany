namespace Presentation.Views.UserControls.Clients;

public partial class DeleteClientsView : UserControl
{
    private readonly IDeleteClientsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteClientsViewModel>();

    public DeleteClientsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}