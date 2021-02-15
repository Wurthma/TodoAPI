using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Domain.Handlers.CommandHandlers;
using Todo.Domain.RequestModels.CommandRequestModels;
using Todo.Domain.ResponseModels;
using Todo.Domain.Tests.Repositories;
using Xunit;

namespace Todo.Domain.Tests.HandlerTests
{
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoRequestModel _invalidCommand = new CreateTodoRequestModel("", "", DateTime.Now);
        private readonly CreateTodoRequestModel _validCommand = new CreateTodoRequestModel("Título da Tarefa", "wurthmann", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResponseModel _result = new GenericCommandResponseModel();

        public CreateTodoHandlerTests()
        {

        }

        [Fact]
        public async Task Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResponseModel) (await _handler.Handle(_invalidCommand, new CancellationToken()));
            Assert.False(_result.Success);
        }

        [Fact]
        public async Task Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (GenericCommandResponseModel) (await _handler.Handle(_validCommand, new CancellationToken()));
            Assert.True(_result.Success);
        }
    }
}