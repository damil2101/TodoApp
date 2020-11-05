using System;
using Todo.Models;
using Microsoft.EntityFrameworkCore;

namespace Todo.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TODO> Todos { get; set; }
    }
}
