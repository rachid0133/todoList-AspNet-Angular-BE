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
            new Todo {id=1, text = "text11"},
            new Todo {id=2,text = "text22"},
            new Todo {id=3,text = "text33"},
            new Todo {id=4,text = "text44"},
            new Todo {id=5,text = "text55"}
        };

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var nonCompletedTodos = AllTodos.Where(t => !t.completed);
            return Ok(nonCompletedTodos);
        }

        [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {
            AllTodos.Add(todo);
            return Ok(todo);
        }

        [HttpPost("{id}")]
        public IActionResult CompletedTodo(int id)
        {
            var todo = AllTodos.SingleOrDefault(t => t.id == id);
            if (todo != null)
            {
                todo.completed = true;
            }
            return Ok(todo);
        }
    }
}
