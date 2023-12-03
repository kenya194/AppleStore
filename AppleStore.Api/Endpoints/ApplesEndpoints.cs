using AppleStore.Api.Entities;
using AppleStore.Api.Repositories;

namespace AppleStore.Api.Endpoints;

public static class ApplesEndpoints
{
    const String GetAppleEndPointName = "GetApple";

    public static RouteGroupBuilder MapApplesEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemApplesRepository repository = new();

        var group = routes.MapGroup("/apples")
               .WithParameterValidation();
               //the parameter validation was incorporated from the resource in the minimal api extension from nuget (its function is to validate the inputs from the data annotations => required, stringlength etc) 
//we are using the group to route the app

group.MapGet("/", () => repository.GetAll());

// rendering the product objects
group.MapGet("/{id}", (int id) => 
{
      Apple? apple = repository.Get(id);

        if (apple is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(apple);
})
.WithName(GetAppleEndPointName);
// Get item by id number.
// app.MapGet("/apples/{name}", (string name) =>apples.Find(apple => apple.Name == name));
// get item by item name

group.MapPost("/", (Apple apple) =>
{
    repository.Create(apple);

    return Results.CreatedAtRoute(GetAppleEndPointName, new {id = apple.Id}, apple);
    // get maximum number and add the new product. (we are creating a resource)
});

group.MapPut("/{Id}", (int id, Apple updatedApple) =>
 {
        Apple? existingApple = repository.Get(id);

        if (existingApple is null)
        {
            return Results.NotFound();
        }

        existingApple.Id = updatedApple.Id;
        existingApple.Name = updatedApple.Name;
        existingApple.Storage = updatedApple.Storage;
        existingApple.Price = updatedApple.Price;
        existingApple.ImageUri = updatedApple.ImageUri;

        repository.Update(existingApple);

        return Results.NoContent();
        //updating a resource thus the apple product.

});
//Next we are going to implement the delete function.
group.MapDelete("/{Id}", (int id) => 
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