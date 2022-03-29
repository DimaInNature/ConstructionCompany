namespace Domain.Models;

public class Worker : IDomainModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Specialization { get; set; }
    public string? Phone { get; set; }

    public int ConstructionId { get; set; }
    public virtual Construction? Construction { get; set; }

    [NotMapped]
    public string FullName => $"{Name} {Surname} {Patronymic}";
}