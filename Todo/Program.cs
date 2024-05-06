using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Adicionando suporte aos controllers da aplicação
builder.Services.AddDbContext<AppDbContext>(); // Usa como serviço

var app = builder.Build();

app.MapControllers(); // mapeando os controllers

app.Run();
