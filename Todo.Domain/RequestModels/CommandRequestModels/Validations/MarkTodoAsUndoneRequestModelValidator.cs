using FluentValidation;

namespace Todo.Domain.RequestModels.CommandRequestModels.Validations
{
    public class MarkTodoAsUndoneRequestModelValidator : AbstractValidator<MarkTodoAsUndoneRequestModel>
    {
        public MarkTodoAsUndoneRequestModelValidator()
        {
            RuleFor(x => x.User).MinimumLength(6).WithMessage("Usuário inválido.");
        }
    }
}