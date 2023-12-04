using System.ComponentModel.DataAnnotations;

namespace AppleStore.Api.Dtos; 

public record AppleDto(
    int Id,
    string Name,
    string Storage,
    decimal Price,
    string ImageUri
);


public record CreateAppleDto(
    [Required][StringLength(20)] string Name,
    string Storage,
    decimal Price,
    string ImageUri
);
public record UpdateAppleDto(
    [Required][StringLength(20)] string Name,
    string Storage,
    decimal Price,
    string ImageUri
);