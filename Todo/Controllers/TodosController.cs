using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repo;

        public TodosController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            IEnumerable<TODO> todos = await _repo.GetTodos();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TODO todo = await _repo.GetTodo(id);

            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todo);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] TODO todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add<TODO>(todo);

            if (await _repo.SaveAll())
            {
                return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
            }
            else
            {
                return BadRequest("Failed to Add todo");
            }
        }
    }
}
