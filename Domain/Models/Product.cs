namespace Domain.Models;

public class Product : IDomainModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public double PricePerUnit { get; set; }
    public int Quantity { get; set; }

    [NotMapped]
    public string? FormatQuantityString { get; set; }

    [NotMapped]
    public string? FormatPricePerUnitString { get; set; }
}