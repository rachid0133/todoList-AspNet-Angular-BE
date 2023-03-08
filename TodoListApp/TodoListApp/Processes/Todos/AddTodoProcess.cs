using AutoMapper;
using MediatR;
using TodoListApp.Entities;
using TodoListApp.Models;

namespace TodoListApp.Processes.Todos
{
    public class AddTodoProcess
    {
        //Request
        public class Request : IRequest<bool>
        {

            public string text { get; set; }
        }


        //handler
        public class Handler : IRequestHandler<Request, bool>
        {

            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var maxId = TodoEntity.AllTodos.Max(t => t.id);
                var todo = new TodoEntity
                {
                    id = maxId + 1,
                    text = request.text,
                    completed = false
                };
                TodoEntity.AllTodos.Add(todo);

                return true;
            }
        }


    }
}
