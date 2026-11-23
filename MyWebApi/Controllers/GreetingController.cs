using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;

namespace MyWebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {
    private readonly IGreetingService _greetingService;

    //Внедрение зависимости через конструктор
    public GreetingController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    [HttpGet("{name}")]
    public IActionResult SayHello(string name)
    {
        var message = _greetingService.GetGreeting(name);
        return Ok(message); // Возвращаем HTTP 200 с текстом
    }
}
