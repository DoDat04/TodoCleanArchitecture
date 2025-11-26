using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCleanArch.Application.Interfaces;
using TodoCleanArch.Application.Interfaces.Repositories;
using TodoCleanArch.Domain.Entities;
using TodoCleanArch.Infrastructure.Context;

namespace TodoCleanArch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoListContext _context;
        public IGenericRepository<TodoItem> TodoItems { get; }

        public UnitOfWork(TodoListContext context)
        {
            _context = context;
            TodoItems = new GenericRepository<TodoItem>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
