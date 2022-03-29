namespace Presentation.ViewModels.UserControls.Products;

internal class ProductsViewModel
    : BaseMenuViewModel, IProductsViewModel
{
    public ProductsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadProductsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadProductsView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateProductsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteProductsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadProductsView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateProductsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteProductsView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowCreatePageCommand = new RelayCommand(executeAction: ExecuteShowCreatePage,
           canExecuteFunc: CanExecuteShowCreatePage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}