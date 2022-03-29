namespace Presentation.ViewModels.UserControls.Products;

internal class DeleteProductsViewModel
    : BaseDeleteViewModel<Product>, IDeleteProductsViewModel
{
    private readonly IProductFacadeService _productService;

    public DeleteProductsViewModel(IProductFacadeService productService)
    {
        _productService = productService;

        InitializeCommands();

        Task.Run(InitializeData);
    }

    #region Command Logic

    #region Can Execute

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedItem is not null;

    #endregion

    #region Execute

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedItem is null) return;

        await _productService.DeleteAsync(SelectedItem.Id);

        MessageBox.Show(
           messageBoxText: "Удаление произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _lastItemId = null;
    }

    private async Task InitializeData()
    {
        Items = await _productService.GetProductListAsync();
    }

    #endregion
}