using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<TODO> GetTodo(int id)
        {
            return await _context.Todos.Where(td => td.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TODO>> GetTodos()
        {
            IEnumerable<TODO> todos = await _context.Todos.ToListAsync();
            return todos;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}