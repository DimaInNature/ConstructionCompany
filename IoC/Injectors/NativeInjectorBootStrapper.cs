namespace IoC.Injectors;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddTransient<IClientRepositoryService, ClientRepositoryService>();
        services.AddTransient<IClientFacadeService, ClientFacadeService>();

        services.AddTransient<IWorkerRepositoryService, WorkerRepositoryService>();
        services.AddTransient<IWorkerFacadeService, WorkerFacadeService>();

        services.AddTransient<IProductRepositoryService, ProductRepositoryService>();
        services.AddTransient<IProductFacadeService, ProductFacadeService>();

        services.AddTransient<IConstructionRepositoryService, ConstructionRepositoryService>();
        services.AddTransient<IConstructionFacadeService, ConstructionFacadeService>();

        services.AddSingleton<UserSessionService>();
    }
}