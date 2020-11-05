using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Data;

namespace Todo.Helpers
{
    public class DataSeeder
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (var context = new TodoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoDbContext>>()))
            {
                // look for any existing Todos 
                if (context.Todos.Any())
                {
                    return;
                }

                context.Todos.Add(new Models.TODO()
                {
                    Id = 1,
                    Description = "Sample Todo Item"
                });

                context.SaveChanges();
            }
        }
    }
}
