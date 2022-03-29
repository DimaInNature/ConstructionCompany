namespace Domain.Models;

public class User : IDomainModel
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public UserRole Role { get; set; }
}