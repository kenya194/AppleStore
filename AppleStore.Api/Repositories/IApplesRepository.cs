using AppleStore.Api.Entities;

namespace AppleStore.Api.Repositories;

public interface IApplesRepository
{
    void Create(Apple apple);
    void Delete(int id);
    Apple? Get(int id);
    IEnumerable<Apple> GetAll();
    void Update(Apple updateApple);
}
