using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Data
{
    public interface ITodoRepository
    {
        void Add<T>(T entity) where T : class;

        Task<IEnumerable<TODO>> GetTodos();
        Task<TODO> GetTodo(int id);
        Task<bool> SaveAll();
    }
}
