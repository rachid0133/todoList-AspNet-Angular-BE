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
        public async Task<IActionResult> GetUncompletedTodos([FromQuery] GetUncompletedTodosProcess.Request request, CancellationToken cancellationToken)
        {
           // var nonCompletedTodos = AllTodos.Where(t => !t.completed);
           var response  = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTodos([FromQuery] GetCompletedTodosProcess.Request request, CancellationToken cancellationToken)
        {
            // var nonCompletedTodos = AllTodos.Where(t => !t.completed);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoProcess.Request request, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(request, cancellationToken);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> CompletedTodo([FromRoute] CompleteTodoProcess.Request request, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(request, cancellationToken);
            if (success) return Ok();
            return BadRequest();
        }
    }
}
