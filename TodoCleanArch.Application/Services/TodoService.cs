using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCleanArch.Application.DTOs;
using TodoCleanArch.Application.Interfaces;
using TodoCleanArch.Application.Interfaces.Services;
using TodoCleanArch.Domain.Entities;

namespace TodoCleanArch.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TodoDto> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var todoItem = new TodoItem
            {
                Title = createTodoDto.Title,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.TodoItems.AddAsync(todoItem);
            await _unitOfWork.SaveAsync();

            var todoDto = new TodoDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt
            };

            return todoDto;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todoItem = await _unitOfWork.TodoItems.GetByIdAsync(id);
            if (todoItem == null)
            {
                return false;
            }

            _unitOfWork.TodoItems.Delete(todoItem);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<TodoDto>> GetAllTodosAsync()
        {
            var todoItems = await _unitOfWork.TodoItems.GetAllAsync();
            var todoDtos = todoItems.Select(todoItem => new TodoDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt
            });
            return todoDtos;
        }

        public async Task<TodoDto?> GetTodoByIdAsync(int id)
        {
            var todoItem = await _unitOfWork.TodoItems.GetByIdAsync(id);
            if (todoItem == null)
            {
                return null;
            }
            var todoDto = new TodoDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt
            };
            return todoDto;
        }

        public async Task<TodoDto?> MarkTodoAsCompletedAsync(int id)
        {
            var existingTodo = await _unitOfWork.TodoItems.GetByIdAsync(id);
            if (existingTodo == null)
            {
                return null;
            }

            existingTodo.IsCompleted = !existingTodo.IsCompleted;
            _unitOfWork.TodoItems.Update(existingTodo);
            await _unitOfWork.SaveAsync();
            var todoDto = new TodoDto
            {
                Id = existingTodo.Id,
                Title = existingTodo.Title,
                IsCompleted = existingTodo.IsCompleted,
                CreatedAt = existingTodo.CreatedAt
            };
            return todoDto;
        }

        public async Task<TodoDto?> UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto)
        {
            var existingTodo = await _unitOfWork.TodoItems.GetByIdAsync(id);
            if (existingTodo == null)
            {
                return null;
            }

            existingTodo.Title = updateTodoDto.Title;
            existingTodo.IsCompleted = updateTodoDto.IsCompleted;

            _unitOfWork.TodoItems.Update(existingTodo);
            await _unitOfWork.SaveAsync();

            var todoDto = new TodoDto
            {
                Id = existingTodo.Id,
                Title = existingTodo.Title,
                IsCompleted = existingTodo.IsCompleted,
                CreatedAt = existingTodo.CreatedAt
            };

            return todoDto;
        }
    }
}
