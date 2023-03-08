using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using TodoListApp.Processes.Todos;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private IMediator _mediator;

        /* private static List<Todo> AllTodos = new List<Todo>
            {
            new Todo {id=1, text = "text11"},
            new Todo {id=2,text = "text22"},
            new Todo {id=3,text = "text33"},
            new Todo {id=4,text = "text44"},
            new Todo {id=5,text = "text55"}
            };*/

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos([FromQuery] GetUncompletedTodosProcess.Request request, CancellationToken cancellationToken)
        {
           // var nonCompletedTodos = AllTodos.Where(t => !t.completed);
           var response  = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

       /* [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {
            var maxId = AllTodos.Max(t => t.id);
            todo.id = maxId+1;
            AllTodos.Add(todo);
            return Ok(todo);
        }

        [HttpPost("{id}/complete")]
        public IActionResult CompletedTodo(int id)
        {
            var todo = AllTodos.SingleOrDefault(t => t.id == id);
            if (todo != null)
            {
                todo.completed = true;
            }

            return Ok(todo);
        }*/
    }
}
