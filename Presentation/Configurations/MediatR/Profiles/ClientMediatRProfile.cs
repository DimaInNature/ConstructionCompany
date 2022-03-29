namespace Presentation.Configurations.MediatR.Profiles;

internal static class ClientMediatRProfile
{
    public static void AddClientMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Client>

        services.AddScoped<IRequest<List<Client>?>, GetClientListQuery>();
        services.AddScoped<IRequestHandler<GetClientListQuery, List<Client>?>, GetClientListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateClientCommand>();
        services.AddScoped<IRequestHandler<CreateClientCommand, Unit>, CreateClientCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteClientCommand>();
        services.AddScoped<IRequestHandler<DeleteClientCommand, Unit>, DeleteClientCommandHandler>();

        #endregion
    }
}