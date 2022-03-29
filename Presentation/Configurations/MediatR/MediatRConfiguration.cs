namespace Presentation.Configurations.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddUserMediatRProfile();

        services.AddConstructionMediatRProfile();

        services.AddClientMediatRProfile();

        services.AddWorkerMediatRProfile();

        services.AddProductMediatRProfile();
    }
}