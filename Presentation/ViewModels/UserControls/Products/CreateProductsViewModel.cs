namespace Presentation.ViewModels.UserControls.Products;

internal class CreateProductsViewModel
    : BaseCreateViewModel, ICreateProductsViewModel
{
    #region Members

    #region Properties

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string UnitOfMeasurement
    {
        get => _unitOfMeasurement ?? string.Empty;
        set
        {
            _unitOfMeasurement = value;
            OnPropertyChanged(nameof(UnitOfMeasurement));
        }
    }

    public double? PricePerUnit
    {
        get => _pricePerUnit;
        set
        {
            _pricePerUnit = value;
            OnPropertyChanged(nameof(PricePerUnit));
        }
    }

    public int? Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _unitOfMeasurement;

    private double? _pricePerUnit;

    private int? _quantity;

    #endregion

    #region Dependencies

    private readonly IProductFacadeService _productService;

    #endregion

    #endregion

    public CreateProductsViewModel(IProductFacadeService productService)
    {
        _productService = productService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, UnitOfMeasurement)
        && PricePerUnit > 0 && Quantity > 0;

    protected override async void ExecuteCreate(object obj)
    {
        Product product = new()
        {
            Name = Name,
            Quantity = Quantity ?? 0,
            PricePerUnit = PricePerUnit ?? 0,
            UnitOfMeasurement = UnitOfMeasurement
        };

        await _productService.CreateAsync(product);

        MessageBox.Show(
            messageBoxText: "Добавление произошло успешно",
            caption: "Успех",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Name = string.Empty;
        UnitOfMeasurement = string.Empty;
        PricePerUnit = null;
        Quantity = null;
    }

    #endregion
}