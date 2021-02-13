using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public Task CreateAsync(TodoItem todo)
        {
            return Task.FromResult(0);
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync(string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllDoneAsync(string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllUndoneAsync(string user)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetByPeriodAsync(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItem todo)
        {
            return Task.FromResult(0);
        }
    }
}