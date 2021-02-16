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
        private readonly CreateTodoRequestModel _invalidCreateCommand = new CreateTodoRequestModel("", "", DateTime.Now);
        private readonly CreateTodoRequestModel _validCreateCommand = new CreateTodoRequestModel("Título da Tarefa", "wurthmann", DateTime.Now);
        private readonly UpdateTodoRequestModel _invalidUpdateCommand = new UpdateTodoRequestModel(Guid.Parse("c4609486-65b7-4f59-b36e-d22dcf104ab2"), "", "");
        private readonly UpdateTodoRequestModel _validUpdateCommand = new UpdateTodoRequestModel(Guid.Parse("fe34b201-5e9d-4f56-9618-0825cb99547d"), "Estudar", "wurthmann");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResponseModel _result = new GenericCommandResponseModel();

        public CreateTodoHandlerTests()
        {

        }

        [Fact]
        public async Task Dado_um_comando_create_invalido_deve_interromper_a_execucao()
        {
            _result = await _handler.Handle(_invalidCreateCommand, new CancellationToken());
            Assert.False(_result.Success);
        }

        [Fact]
        public async Task Dado_um_comando_create_valido_deve_criar_a_tarefa()
        {
            _result = await _handler.Handle(_validCreateCommand, new CancellationToken());
            Assert.True(_result.Success);
        }

        [Fact]
        public async Task Dado_um_comando_update_invalido_deve_interromper_a_execucao()
        {
            _result = await _handler.Handle(_invalidUpdateCommand, new CancellationToken());
            Assert.False(_result.Success);
        }

        // ...
    }
}