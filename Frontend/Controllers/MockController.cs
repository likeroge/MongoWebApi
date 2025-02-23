using Frontend.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;

namespace Frontend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MockController : ControllerBase
{
    private readonly HttpClient _httpClient;
    
    public MockController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public IActionResult FetchData()
    {
        var stringAsync = _httpClient.GetStringAsync("/api/users").Result;
        return Ok(stringAsync);
    }
}