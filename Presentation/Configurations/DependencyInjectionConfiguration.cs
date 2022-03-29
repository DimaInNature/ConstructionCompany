namespace Presentation.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<ILoginViewModel, LoginViewModel>();

        services.AddTransient<IMainViewModel, MainViewModel>();

        services.AddTransient<IClientsViewModel, ClientsViewModel>();
        services.AddTransient<IReadClientsViewModel, ReadClientsViewModel>();
        services.AddTransient<ICreateClientsViewModel, CreateClientsViewModel>();
        services.AddTransient<IDeleteClientsViewModel, DeleteClientsViewModel>();

        services.AddTransient<IConstructionsViewModel, ConstructionsViewModel>();
        services.AddTransient<IReadConstructionsViewModel, ReadConstructionsViewModel>();
        services.AddTransient<ICreateConstructionsViewModel, CreateConstructionsViewModel>();
        services.AddTransient<IDeleteConstructionsViewModel, DeleteConstructionsViewModel>();

        services.AddTransient<IProductsViewModel, ProductsViewModel>();
        services.AddTransient<IReadProductsViewModel, ReadProductsViewModel>();
        services.AddTransient<ICreateProductsViewModel, CreateProductsViewModel>();
        services.AddTransient<IDeleteProductsViewModel, DeleteProductsViewModel>();

        services.AddTransient<IReportsViewModel, ReportsViewModel>();

        services.AddTransient<IUsersViewModel, UsersViewModel>();
        services.AddTransient<IReadUsersViewModel, ReadUsersViewModel>();
        services.AddTransient<ICreateUsersViewModel, CreateUsersViewModel>();
        services.AddTransient<IDeleteUsersViewModel, DeleteUsersViewModel>();
        services.AddTransient<IUpdateUsersViewModel, UpdateUsersViewModel>();

        services.AddTransient<IWorkersViewModel, WorkersViewModel>();
        services.AddTransient<IReadWorkersViewModel, ReadWorkersViewModel>();
        services.AddTransient<IDeleteWorkersViewModel, DeleteWorkersViewModel>();
        services.AddTransient<ICreateWorkersViewModel, CreateWorkersViewModel>();
    }
}