using FluentValidation;

namespace Todo.Domain.RequestModels.CommandRequestModels.Validations
{
    public class MarkTodoAsDoneRequestModelValidator : AbstractValidator<MarkTodoAsDoneRequestModel>
    {
        public MarkTodoAsDoneRequestModelValidator()
        {
            RuleFor(x => x.User).MinimumLength(6).WithMessage("Usuário inválido.");
        }
    }
}