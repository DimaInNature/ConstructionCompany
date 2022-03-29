namespace Presentation.Views.UserControls.Constructions;

public partial class DeleteConstructionsView : UserControl
{
    private readonly IDeleteConstructionsViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IDeleteConstructionsViewModel>();

    public DeleteConstructionsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}