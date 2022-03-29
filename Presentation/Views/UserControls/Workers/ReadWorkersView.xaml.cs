namespace Presentation.Views.UserControls.Workers;

public partial class ReadWorkersView : UserControl
{
    private readonly IReadWorkersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadWorkersViewModel>();

    public ReadWorkersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}