using AutoMapper;
using MediatR;
using TodoListApp.Entities;

namespace TodoListApp.Processes.Todos
{
    public class GetUncompletedTodosProcess
    {
        //Request
        public class Request : IRequest<List<Response>> { }


        //Response
        public class Response {
            public int id { get; set; }
            public string text { get; set; }
        }


        //handler
        public class Handler : IRequestHandler<Request, List<Response>>
        {
            private readonly IMapper _mapper;
            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }
            public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var nonCompletedTodos = TodoEntity.AllTodos.Where(t => !t.completed);
                var resp = _mapper.Map<List<Response>>(nonCompletedTodos);
                return resp;
            }
        }
        //Validator


        //Mapper
        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<TodoEntity, Response>();
            }
        }


    }
}
