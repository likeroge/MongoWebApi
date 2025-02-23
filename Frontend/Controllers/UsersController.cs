using Frontend.Models;
using Frontend.Models.DTO;
using Frontend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController
{
    private readonly UserRepository _users;
    
    public UsersController(UserRepository users)
    {
        _users = users;
    }
    
    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _users.GetAll();
    }
    
    [HttpGet("{id}")]
    public async Task<User> Get(string id)
    {
        return await _users.GetOne(id);
    }
    
    [HttpPost]
    public async Task<User> Post(CreateUserDto dto)
    {
        Console.WriteLine(dto.Name);
        Console.WriteLine(dto.Email);
        return await _users.Create(dto);
    }
    
    [HttpDelete("{id}")] public async Task Delete(string id) => await _users.Delete(id); 
}