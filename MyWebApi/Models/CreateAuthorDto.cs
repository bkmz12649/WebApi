namespace MyWebApi.Models
{
    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public List<string> BookTitles { get; set; } = new(); // Просто список названий книг
    }
}
