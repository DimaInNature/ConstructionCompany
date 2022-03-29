namespace Presentation.Configurations.MediatR.Profiles;

internal static class WorkerMediatRProfile
{
    public static void AddWorkerMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Worker>

        services.AddScoped<IRequest<List<Worker>?>, GetWorkerListQuery>();
        services.AddScoped<IRequestHandler<GetWorkerListQuery, List<Worker>?>, GetWorkerListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateWorkerCommand>();
        services.AddScoped<IRequestHandler<CreateWorkerCommand, Unit>, CreateWorkerCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteWorkerCommand>();
        services.AddScoped<IRequestHandler<DeleteWorkerCommand, Unit>, DeleteWorkerCommandHandler>();

        #endregion
    }
}