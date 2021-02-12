using FluentValidation;

namespace Todo.Domain.RequestModels.CommandRequestModels.Validations
{
    public class UpdateTodoRequestModelValidator : AbstractValidator<UpdateTodoRequestModel>
    {
        public UpdateTodoRequestModelValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Por favor, descreva melhor essa tarefa.");
            RuleFor(x => x.User).MinimumLength(6).WithMessage("Usuário inválido.");
        }
    }
}