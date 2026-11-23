namespace MyWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public int AuthorId { get; set; } // Внешний ключ
        public Author Author { get; set; } // Связь

    }
}
