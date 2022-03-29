namespace Domain.Models;

public class Construction : IDomainModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Address { get; set; }

    public int ClientId { get; set; }
    public virtual Client? Client { get; set; }

    public virtual List<Worker>? Workers { get; set; }

    [NotMapped]
    public int WorkersCount
    {
        get => Workers?.Count ?? 0;
        set => _workersCount = value;
    }

    [NotMapped]
    private int _workersCount;

    [NotMapped]
    public string? EndDateString => EndDate.ToString();
}