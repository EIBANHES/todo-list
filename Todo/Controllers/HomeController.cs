using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    // define que é o controle de api
    // Os metodos dentro do controller sao chamados de -> action
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<TodoModel> Get([FromServices]AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        public TodoModel GetById([FromRoute] int id, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            return context.Todos.FirstOrDefault(x => x.Id == id); // pegando por id 
        }

        [HttpPost("/")]
        public TodoModel Post([FromBody] TodoModel todo, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return todo;
        }        
        
        [HttpPut("/{id:int}")]
        public TodoModel Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return model;

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return model;
        }

        [HttpDelete("/{id:int}")]
        public TodoModel Put([FromRoute] int id, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }

    }
}
