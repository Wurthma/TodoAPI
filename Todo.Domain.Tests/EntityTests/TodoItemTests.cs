using System;
using Xunit;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo Aqui", "andrebaltieri", DateTime.Now);

        [Fact]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.False(_validTodo.Done);
        }
    }
}