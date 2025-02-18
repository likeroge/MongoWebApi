using MongoDB.Driver;
using MongoWebApi.Data.Context;
using MongoWebApi.Models;
using MongoWebApi.Models.DTO;
using MongoWebApi.Repos.Interfaces;

namespace MongoWebApi.Repos;

public class UserRepository : ICrud<User>
{

    private readonly IMongoCollection<User> _users;

    public UserRepository(MongoDbContext context)
    {
        _users = context.Users;
    }


    public async Task<IEnumerable<User>> GetAll()
    {
        return await _users.Find(_ => true).ToListAsync();
    }

    public async Task<User> GetOne(string id)
    {
        return await _users.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task Delete(string id)
    { 
        await _users.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<User> Create(CreateUserDto dto)
    {
        User user = new User
        {
Name = dto.Name,
Email = dto.Email
        };
         await _users.InsertOneAsync(user);
         return user;
    }
}