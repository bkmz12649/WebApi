using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Models; // Где лежат модели

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _db;

    // Внедряем базу данных
    public AuthorsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        // 1. Загружаем авторов с их книгами (Include)
        var authors = await _db.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .ToListAsync();

        // 2. Превращаем в DTO, чтобы не отдавать циклические ссылки
        var result = authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name,
            BookTitles = a.Books.Select(b => b.Title).ToList()
        }).ToList();

        // 3. Возвращаем 200 OK с массивом
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
    {
        // 1. Создаем автора
        var author = new Author
        {
            Name = dto.Name,
            // 2. Создаем книги на основе переданных названий
            Books = dto.BookTitles.Select(title => new Book { Title = title, Year = 2024 }).ToList()
        };

        // 3. Добавляем в БД и сохраняем
        _db.Authors.Add(author);
        await _db.SaveChangesAsync();

        // 4. Возвращаем результат
        return Ok($"Автор {author.Name} успешно добавлен с ID: {author.Id}");
    }
}

