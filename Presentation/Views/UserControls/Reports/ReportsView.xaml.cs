namespace Presentation.Views.UserControls.Reports;

public partial class ReportsView : UserControl
{
    private readonly IReportsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReportsViewModel>();

    public ReportsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}