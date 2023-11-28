using AppleStore.Api.Entities;

const String GetAppleEndPointName = "GetApple";

List<Apple> apples = new()
{
    new Apple()
    {
        Id = 1,
        Name = "Iphone X",
        Storage = "64gb",
        Price = 2500.00M,
        ImageUri = "https://placehold.co/100"
    },
    new Apple()
    {
        Id = 2,
        Name = "Iphone X",
        Storage = "256gb",
        Price = 2700.00M,
        ImageUri = "https://placehold.co/100"
    },
    new Apple()
    {
        Id = 3,
        Name = "Iphone XR",
        Storage = "64gb",
        Price = 2600.00M,
        ImageUri = "https://placehold.co/100"
    },
    new Apple()
    {
        Id = 4,
        Name = "Iphone XR",
        Storage = "128gb",
        Price = 2800.00M,
        ImageUri = "https://placehold.co/100"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/apples", () => apples); 
// rendering the product objects
app.MapGet("/apples/{id}", (int id) => 
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
app.MapPost("/apples", (Apple apple) =>
{
    apple.Id = apples.Max(apple => apple.Id) + 1;
    apples.Add(apple);

    return Results.CreatedAtRoute(GetAppleEndPointName, new {id = apple.Id}, apple);
    // get maximum number and add the new product. 
});
// app.MapGet("/apples/{name}", (string name) =>apples.Find(apple => apple.Name == name));
// get item by item name

app.Run();
