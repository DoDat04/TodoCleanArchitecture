using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCleanArch.Application.Interfaces.Repositories;
using TodoCleanArch.Domain.Entities;

namespace TodoCleanArch.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TodoItem> TodoItems { get; }
        Task SaveAsync();
    }
}
