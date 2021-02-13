using MediatR;

namespace Todo.Domain.Interfaces.ICommandHandlers
{
    public interface IGenericCommandResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}