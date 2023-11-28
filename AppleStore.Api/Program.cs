using AppleStore.Api.Entities;

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
app.MapGet("/apples/{id}", (int id) => apples.Find(apple => apple.Id == id));
// Get item by id number.
// app.MapGet("/apples/{name}", (string name) =>apples.Find(apple => apple.Name == name));
// get item by item name

app.Run();
