using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    // define que é o controle de api
    // Os metodos dentro do controller sao chamados de -> action
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get() 
        {
            return "Hello World";
        }
    }
}
