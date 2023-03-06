using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly List<Todo> AllTodos = new List<Todo>
        {
            new Todo {text = "text11"},
            new Todo {text = "text22"},
            new Todo {text = "text33"},
            new Todo {text = "text44"}
        };

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var nonCompletedTodos = AllTodos.Where(t => !t.completed);
            return Ok(nonCompletedTodos);
        }
    }
}
