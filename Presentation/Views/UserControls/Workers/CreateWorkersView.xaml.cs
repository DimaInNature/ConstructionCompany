namespace Presentation.Views.UserControls.Workers;

public partial class CreateWorkersView : UserControl
{
    private readonly ICreateWorkersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateWorkersViewModel>();

    public CreateWorkersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}