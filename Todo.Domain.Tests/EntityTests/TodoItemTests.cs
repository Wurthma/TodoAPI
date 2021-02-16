using System;
using Xunit;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo Aqui", "wurthmann", DateTime.Now);

        [Fact]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.False(_validTodo.Done);
        }

        [Fact]
        public void Ao_chamar_MarkAsDone_prop_done_deve_ser_true()
        {
            _validTodo.MarkAsDone();
            Assert.True(_validTodo.Done);
        }

        [Fact]
        public void Ao_chamar_MarkAsUndone_prop_done_deve_ser_false()
        {
            _validTodo.MarkAsUndone();
            Assert.False(_validTodo.Done);
        }

        [Fact]
        public void Ao_mudar_titulo_prop_Tittle_deve_conter_o_texto_informado()
        {
            string newTitle = "Ir ao dentista";
            _validTodo.UpdateTitle(newTitle);
            Assert.Equal(newTitle, _validTodo.Title);
        }
    }
}