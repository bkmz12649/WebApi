using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;
using MyWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//https://localhost:7035/swagger/index.html
// Добавляем сервисы для Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Региструем сервис
builder.Services.AddTransient<IGreetingService, GreetingService>();//Transient сервис
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlite("Data Source=library_ef.db")); //Подключение к БД

var app = builder.Build();

// Включаем Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();