namespace Domain.Models;

public class Client : IDomainModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Phone { get; set; }

    [NotMapped]
    public string FullName => $"{Name} {Surname} {Patronymic}";
}