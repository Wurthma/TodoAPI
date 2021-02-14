using System;
using FluentValidation.Results;
using Todo.Domain.Interfaces.ICommandHandlers;
using Todo.Domain.RequestModels.CommandRequestModels.Validations;
using Todo.Domain.ResponseModels;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class MarkTodoAsUndoneRequestModel : IRequestValidateble<GenericCommandResponseModel>
    {
        private MarkTodoAsUndoneRequestModelValidator _validator { get; set; }
        
        public MarkTodoAsUndoneRequestModel()
        {
            _validator = new MarkTodoAsUndoneRequestModelValidator();
        }
        
        public MarkTodoAsUndoneRequestModel(Guid id, string user)
        {
            Id = id;
            User = user;
            _validator = new MarkTodoAsUndoneRequestModelValidator();
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public ValidationResult Validate() => _validator.Validate(this);
    }
}