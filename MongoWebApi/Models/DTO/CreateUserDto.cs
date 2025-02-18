using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MongoWebApi.Models.DTO;

public record CreateUserDto(
    [NotNull]
    string Name,
    
    [NotNull]
    [MinLength(5)]
    string Email
    );