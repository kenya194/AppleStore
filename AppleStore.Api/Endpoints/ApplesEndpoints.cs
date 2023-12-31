using AppleStore.Api.Dtos;
using AppleStore.Api.Entities;
using AppleStore.Api.Repositories;

namespace AppleStore.Api.Endpoints;

public static class ApplesEndpoints
{
    const String GetAppleEndPointName = "GetApple";

    public static RouteGroupBuilder MapApplesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/apples")
               .WithParameterValidation();
               //the parameter validation was incorporated from the resource in the minimal api extension from nuget (its function is to validate the inputs from the data annotations => required, stringlength etc) 
//we are using the group to route the app

group.MapGet("/", (IApplesRepository repository) => repository.GetAll().Select(apple => apple.AsDto()));

// rendering the product objects
group.MapGet("/{id}", (IApplesRepository repository, int id) => 
{
      Apple? apple = repository.Get(id);

        if (apple is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(apple.AsDto());
})
.WithName(GetAppleEndPointName);
// Get item by id number.
// app.MapGet("/apples/{name}", (string name) =>apples.Find(apple => apple.Name == name));
// get item by item name

group.MapPost("/", (IApplesRepository repository, CreateAppleDto appleDto) =>
{
    Apple apple = new()
    {
        Name = appleDto.Name,
        Storage = appleDto.Storage,
        Price = appleDto.Price,
        ImageUri = appleDto.ImageUri,
    };


    repository.Create(apple);

    return Results.CreatedAtRoute(GetAppleEndPointName, new {id = apple.Id}, apple);
    // get maximum number and add the new product. (we are creating a resource)
});

group.MapPut("/{Id}", (IApplesRepository repository, int id, UpdateAppleDto updatedAppleDto) =>
 {
        Apple? existingApple = repository.Get(id);

        if (existingApple is null)
        {
            return Results.NotFound();
        }

        // existingApple.Id = updatedAppleDto.Id;
        existingApple.Name = updatedAppleDto.Name;
        existingApple.Storage = updatedAppleDto.Storage;
        existingApple.Price = updatedAppleDto.Price;
        existingApple.ImageUri = updatedAppleDto.ImageUri;

        repository.Update(existingApple);

        return Results.NoContent();
        //updating a resource thus the apple product.

});
//Next we are going to implement the delete function.
group.MapDelete("/{Id}", (IApplesRepository repository, int id) => 
{
      Apple? apple = repository.Get(id);

        if (apple is not null)
        {
            repository.Delete(id);
        }

        return Results.NoContent();
});
        return group;
    }
}