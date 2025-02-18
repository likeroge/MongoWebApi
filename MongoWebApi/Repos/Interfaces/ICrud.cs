namespace MongoWebApi.Repos.Interfaces;

public interface ICrud<T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetOne(string id);
    // public Task Add(T t);
    // public Task Update(T t);
    public Task Delete(string id);
}