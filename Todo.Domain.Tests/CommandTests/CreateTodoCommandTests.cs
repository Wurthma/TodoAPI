using System;
using Todo.Domain.RequestModels.CommandRequestModels;
using Xunit;

namespace Todo.Domain.Tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoRequestModel _invalidCommand = new CreateTodoRequestModel("", "", DateTime.Now);
        private readonly CreateTodoRequestModel _validCommand = new CreateTodoRequestModel("Título da Tarefa", "wurthmann", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [Fact]
        public void Dado_um_comando_invalido()
        {
            Assert.False(_invalidCommand.Validate().IsValid);
        }

        [Fact]
        public void Dado_um_comando_valido()
        {
            Assert.True(_validCommand.Validate().IsValid);
        }
    }
}
