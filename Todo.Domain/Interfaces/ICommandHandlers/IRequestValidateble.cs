using FluentValidation.Results;
using MediatR;

namespace Todo.Domain.Interfaces.ICommandHandlers
{
    public interface IRequestValidateble<T> : IRequest<T>
    {
        ValidationResult Validate();
    }
}