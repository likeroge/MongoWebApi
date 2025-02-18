using MongoWebApi.Models.Base;

namespace MongoWebApi.Models;

public class User : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; } 
}