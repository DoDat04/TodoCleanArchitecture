using Microsoft.AspNetCore.Mvc;
using TodoCleanArch.Application.DTOs;
using TodoCleanArch.Application.Interfaces.Services;

namespace TodoCleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodosAsync()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id:int}", Name = nameof(GetTodoByIdAsync))]
        public async Task<ActionResult<TodoDto>> GetTodoByIdAsync(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateTodoAsync([FromBody] CreateTodoDto createTodoDto)
        {
            var createdTodo = await _todoService.CreateTodoAsync(createTodoDto);
            return CreatedAtRoute(nameof(GetTodoByIdAsync), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TodoDto>> UpdateTodoAsync(int id, [FromBody] UpdateTodoDto updateTodoDto)
        {
            var updatedTodo = await _todoService.UpdateTodoAsync(id, updateTodoDto);
            if (updatedTodo is null)
            {
                return NotFound();
            }

            return Ok(updatedTodo);
        }

        [HttpPatch("toggle/{id:int}")]
        public async Task<ActionResult<TodoDto>> ToggleTodoCompletionAsync(int id)
        {
            var toggledTodo = await _todoService.MarkTodoAsCompletedAsync(id);
            if (toggledTodo is null)
            {
                return NotFound();
            }
            return Ok(toggledTodo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            var deleted = await _todoService.DeleteTodoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
