using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Queries;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TodoItem todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync(string user)
        {
            return await _context.Todos
               .AsNoTracking()
               .Where(TodoQueries.GetAll(user))
               .OrderBy(x => x.Date)
               .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllDoneAsync(string user)
        {
            return await _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllUndoneAsync(string user)
        {
            return await _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            return await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == id && x.User == user);
        }

        public async Task<IEnumerable<TodoItem>> GetByPeriodAsync(string user, DateTime date, bool done)
        {
            return await _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date)
                .ToListAsync();
        }

        public async Task UpdateAsync(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}