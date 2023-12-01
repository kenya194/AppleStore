using System.ComponentModel.DataAnnotations;

namespace AppleStore.Api.Entities;

public class Apple
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    //The required method ensures the object has a name and a lenght less than the specified range.
    public required string Name { get; set; }
    public required string Storage { get; set; }
    public decimal Price { get; set; }
    public required string ImageUri { get; set; }

}