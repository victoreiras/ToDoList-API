namespace ToDoList.Domain.interfaces;

public interface ICacheRepository
{
    Task SetAsync<T>(string key, T value);
    Task<T> GetAsync<T>(string key);
}