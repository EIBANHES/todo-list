var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Adicionando suporte aos controllers da aplicação

var app = builder.Build();

app.MapControllers(); // mapeando os controllers

app.Run();
