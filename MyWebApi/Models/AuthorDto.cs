namespace MyWebApi.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> BookTitles { get; set; } = new();
    }
}
