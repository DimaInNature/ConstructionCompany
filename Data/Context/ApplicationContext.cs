using Enums.User;

namespace Data.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<Construction> Constructions => Set<Construction>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Worker> Workers => Set<Worker>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasIndex(client => client.Id).IsUnique();
        modelBuilder.Entity<Client>().HasData(GetClients());

        modelBuilder.Entity<Construction>().HasIndex(construction => construction.Id).IsUnique();
        modelBuilder.Entity<Construction>().HasData(GetConstructions());

        modelBuilder.Entity<Product>().HasIndex(product => product.Id).IsUnique();
        modelBuilder.Entity<Product>().HasData(GetProducts());

        modelBuilder.Entity<User>().HasIndex(user => user.Id).IsUnique();
        modelBuilder.Entity<User>().HasData(GetUsers());

        modelBuilder.Entity<Worker>().HasIndex(worker => worker.Id).IsUnique();
        modelBuilder.Entity<Worker>().HasData(GetWorkers());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    private List<Client> GetClients() => new();

    private List<Construction> GetConstructions() => new();

    private List<Product> GetProducts() => new();

    private List<User> GetUsers() => new()
    {
        new()
        {
            Id = 1,
            Login = "Admin",
            Password = "Root",
            Role = UserRole.Admin
        },
        new()
        {
            Id = 2,
            Login = "Employee",
            Password = "Root",
            Role = UserRole.Employee
        }
    };

    private List<Worker> GetWorkers() => new();
}