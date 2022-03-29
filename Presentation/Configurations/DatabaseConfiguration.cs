namespace Presentation.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlite(ApplicationConfiguration.ConnectionString);
        });
    }
}