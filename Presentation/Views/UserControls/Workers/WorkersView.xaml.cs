namespace Presentation.Views.UserControls.Workers;

public partial class WorkersView : UserControl
{
    private readonly IWorkersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IWorkersViewModel>();

    public WorkersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}