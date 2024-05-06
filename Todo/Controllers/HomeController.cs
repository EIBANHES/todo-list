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

        // IActionResult -> Padroniza retorno das apis
        public IActionResult Get([FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
            => Ok(context.Todos.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id); // pegando por id
            if (todos == null)
                return NotFound();
            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"{todo.Id}", todo);
        }        
        
        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromServices] AppDbContext context) // injeçao de dependencia, usa o context como serviço
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
