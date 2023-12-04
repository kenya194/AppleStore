using AppleStore.Api.Entities;

namespace AppleStore.Api.Repositories;

public class InMemApplesRepository : IApplesRepository
{
    private readonly List<Apple> apples = new()
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

    public IEnumerable<Apple> GetAll()
    {
        return apples;
    }
    // get all products

    public Apple? Get(int id)
    {
        return apples.Find(apple => apple.Id == id);
    }
    // get by ID

    public void Create(Apple apple)
    {
        apple.Id = apples.Max(game => game.Id) + 1;
        apples.Add(apple);
    }
    //Post products

    public void Update(Apple updatedApple)
    {
        var index = apples.FindIndex(apple => apple.Id == updatedApple.Id);
        apples[index] = updatedApple;
    }

    public void Delete(int id)
    {
        var index = apples.FindIndex(apple => apple.Id == id);
        apples.RemoveAt(index);
    }
    //delete products
}