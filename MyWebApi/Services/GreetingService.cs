namespace MyWebApi.Services
{
    public class GreetingService : IGreetingService
    {
        public string GetGreeting(string name)
        {
            return $"Привет, {name}! Время: {DateTime.Now:T}";
        }
    }
}
