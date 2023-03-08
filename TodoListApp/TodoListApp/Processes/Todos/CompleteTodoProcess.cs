
using MediatR;
using TodoListApp.Entities;

namespace TodoListApp.Processes.Todos
{
    public class CompleteTodoProcess
    {
        public class Request : IRequest<bool>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Request,bool>
        {
            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var todo = TodoEntity.AllTodos.SingleOrDefault(t => t.id == request.id);
                if (todo != null)
                {
                    todo.completed = true;
                }
                return true;
            }
        }


    }
}
