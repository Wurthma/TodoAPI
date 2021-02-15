using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "wurthmann", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "wurthmann", DateTime.Now));
        }

        [Fact]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_andrebaltieri()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("wurthmann"));
            Assert.Equal(2, result.Count());
        }
    }
}