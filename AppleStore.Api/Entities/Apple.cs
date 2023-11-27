namespace AppleStore.Api.Entities;

public class Apple
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Storage { get; set; }
    public decimal Price { get; set; }
    public required string ImageUri { get; set; }

}