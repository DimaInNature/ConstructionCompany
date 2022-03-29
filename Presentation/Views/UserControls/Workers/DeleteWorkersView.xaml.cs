namespace Presentation.Views.UserControls.Workers;

public partial class DeleteWorkersView : UserControl
{
    private readonly IDeleteWorkersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteWorkersViewModel>();

    public DeleteWorkersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}