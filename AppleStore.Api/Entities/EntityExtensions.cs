using AppleStore.Api.Dtos;

namespace AppleStore.Api.Entities;

public static class EntityExtensions
{
    public static AppleDto AsDto(this Apple apple)
    {
        return new AppleDto(
            apple.Id,
            apple.Name,
            apple.Storage,
            apple.Price,
            apple.ImageUri
        );
    }
}