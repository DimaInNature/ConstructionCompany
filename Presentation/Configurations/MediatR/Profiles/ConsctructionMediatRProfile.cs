namespace Presentation.Configurations.MediatR.Profiles;

public static class ConsctructionMediatRProfile
{
    public static void AddConstructionMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Construction>

        services.AddScoped<IRequest<List<Construction>?>, GetConstructionListQuery>();
        services.AddScoped<IRequestHandler<GetConstructionListQuery, List<Construction>?>, GetConstructionListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateConstructionCommand>();
        services.AddScoped<IRequestHandler<CreateConstructionCommand, Unit>, CreateConstructionCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateConstructionCommand>();
        services.AddScoped<IRequestHandler<UpdateConstructionCommand, Unit>, UpdateConstructionCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteConstructionCommand>();
        services.AddScoped<IRequestHandler<DeleteConstructionCommand, Unit>, DeleteConstructionCommandHandler>();

        #endregion
    }
}