using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task CreateAsync(TodoItem todo);
        Task UpdateAsync(TodoItem todo);
        Task<TodoItem> GetByIdAsync(Guid id, string user);
        Task<IEnumerable<TodoItem>> GetAllAsync(string user);
        Task<IEnumerable<TodoItem>> GetAllDoneAsync(string user);
        Task<IEnumerable<TodoItem>> GetAllUndoneAsync(string user);
        Task<IEnumerable<TodoItem>> GetByPeriodAsync(string user, DateTime date, bool done);
    }
}