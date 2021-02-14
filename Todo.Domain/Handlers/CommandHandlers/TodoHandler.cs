using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.RequestModels.CommandRequestModels;
using Todo.Domain.ResponseModels;

namespace Todo.Domain.Handlers.CommandHandlers
{
    public class TodoHandler : 
        IRequestHandler<CreateTodoRequestModel, GenericCommandResponseModel>,
        IRequestHandler<UpdateTodoRequestModel, GenericCommandResponseModel>,
        IRequestHandler<MarkTodoAsDoneRequestModel, GenericCommandResponseModel>,
        IRequestHandler<MarkTodoAsUndoneRequestModel, GenericCommandResponseModel>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenericCommandResponseModel> Handle(CreateTodoRequestModel request, CancellationToken cancellationToken)
        {
            // Fail Fast Validation
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
                return new GenericCommandResponseModel(false, "Ops, parece que sua tarefa está errada!", validationResult.Errors);

            // Gera o TodoItem
            var todo = new TodoItem(request.Title, request.User, request.Date);

            // Salva no banco
            await _repository.CreateAsync(todo);

            // Retorna o resultado
            return new GenericCommandResponseModel(true, "Tarefa salva", todo);
        }

        public async Task<GenericCommandResponseModel> Handle(UpdateTodoRequestModel request, CancellationToken cancellationToken)
        {
            // Fail Fast Validation
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
                return new GenericCommandResponseModel(false, "Ops, parece que sua tarefa está errada!", validationResult.Errors);

            // Recupera o TodoItem (Rehidratação)
            var todo = await _repository.GetByIdAsync(request.Id, request.User);

            // Altera o título
            todo.UpdateTitle(request.Title);

            // Salva no banco
            await _repository.UpdateAsync(todo);

            // Retorna o resultado
            return new GenericCommandResponseModel(true, "Tarefa salva", todo);
        }

        public async Task<GenericCommandResponseModel> Handle(MarkTodoAsDoneRequestModel request, CancellationToken cancellationToken)
        {
            // Fail Fast Validation
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
                return new GenericCommandResponseModel(false, "Ops, parece que sua tarefa está errada!", validationResult.Errors);

            // Recupera o TodoItem
            var todo = await _repository.GetByIdAsync(request.Id, request.User);

            // Altera o estado
            todo.MarkAsDone();

            // Salva no banco
            await _repository.UpdateAsync(todo);

            // Retorna o resultado
            return new GenericCommandResponseModel(true, "Tarefa salva", todo);
        }

        public async Task<GenericCommandResponseModel> Handle(MarkTodoAsUndoneRequestModel request, CancellationToken cancellationToken)
        {
            // Fail Fast Validation
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
                return new GenericCommandResponseModel(false, "Ops, parece que sua tarefa está errada!", validationResult.Errors);

            // Recupera o TodoItem
            var todo = await _repository.GetByIdAsync(request.Id, request.User);

            // Altera o estado
            todo.MarkAsUndone();

            // Salva no banco
            await _repository.UpdateAsync(todo);

            // Retorna o resultado
            return new GenericCommandResponseModel(true, "Tarefa salva", todo);
        }
    }
}