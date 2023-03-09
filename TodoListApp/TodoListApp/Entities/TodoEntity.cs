using TodoListApp.Models;

namespace TodoListApp.Entities
{
    public class TodoEntity
    {
        public static List<TodoEntity> AllTodos = new List<TodoEntity>
        {
            new TodoEntity {id=1, text = "text11"},
            new TodoEntity {id=2,text = "text22"},
            new TodoEntity {id=3,text = "text33"},
            new TodoEntity {id=4,text = "text44", completed=true},
            new TodoEntity {id=5,text = "text55"}
        };

        public int id { get; set; }
        public string text { get; set; }
        public bool completed { get; set; }
    }
}
