using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Adicionando suporte aos controllers da aplica��o
builder.Services.AddDbContext<AppDbContext>(); // Usa como servi�o

var app = builder.Build();

app.MapControllers(); // mapeando os controllers

app.Run();
