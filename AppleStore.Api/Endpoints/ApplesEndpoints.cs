using AppleStore.Api.Entities;

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
group.MapGet("/", () => apples);

// rendering the product objects
group.MapGet("/{id}", (int id) => 
{
      Apple? apple = apples.Find(apple => apple.Id == id);

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
    apple.Id = apples.Max(apple => apple.Id) + 1;
    apples.Add(apple);

    return Results.CreatedAtRoute(GetAppleEndPointName, new {id = apple.Id}, apple);
    // get maximum number and add the new product. (we are creating a resource)
});

group.MapPut("/{Id}", (int id, Apple updatedApple) =>
 {
        Apple? existingApple = apples.Find(apple => apple.Id == id);

        if (existingApple is null)
        {
            return Results.NotFound();
        }

        existingApple.Id = updatedApple.Id;
        existingApple.Name = updatedApple.Name;
        existingApple.Storage = updatedApple.Storage;
        existingApple.Price = updatedApple.Price;
        existingApple.ImageUri = updatedApple.ImageUri;

        return Results.NoContent();
        //updating a resource thus the apple product.

});
//Next we are going to implement the delete function.
group.MapDelete("/{Id}", (int id) => 
{
      Apple? apple = apples.Find(apple => apple.Id == id);

        if (apple is not null)
        {
            apples.Remove(apple);
        }

        return Results.NoContent();
});
        return group;
    }
}