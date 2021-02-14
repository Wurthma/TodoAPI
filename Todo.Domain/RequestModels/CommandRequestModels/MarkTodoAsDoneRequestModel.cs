using System;
using FluentValidation.Results;
using Todo.Domain.Interfaces.ICommandHandlers;
using Todo.Domain.RequestModels.CommandRequestModels.Validations;
using Todo.Domain.ResponseModels;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class MarkTodoAsDoneRequestModel : IRequestValidateble<GenericCommandResponseModel>
    {
        private MarkTodoAsDoneRequestModelValidator _validator { get; set; }
        
        public MarkTodoAsDoneRequestModel()
        {
            _validator = new MarkTodoAsDoneRequestModelValidator();
        }
        
        public MarkTodoAsDoneRequestModel(Guid id, string user)
        {
            Id = id;
            User = user;
            _validator = new MarkTodoAsDoneRequestModelValidator();
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public ValidationResult Validate() => _validator.Validate(this);
    }
}