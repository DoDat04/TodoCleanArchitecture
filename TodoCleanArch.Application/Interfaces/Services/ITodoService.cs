using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCleanArch.Application.DTOs;

namespace TodoCleanArch.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDto>> GetAllTodosAsync();
        Task<TodoDto?> GetTodoByIdAsync(int id);
        Task<TodoDto> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<TodoDto?> UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto);
        Task<bool> DeleteTodoAsync(int id);
        Task<TodoDto?> MarkTodoAsCompletedAsync(int id);
    }
}
