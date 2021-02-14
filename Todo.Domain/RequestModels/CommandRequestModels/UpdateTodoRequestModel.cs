using System;
using FluentValidation.Results;
using Todo.Domain.Interfaces.ICommandHandlers;
using Todo.Domain.RequestModels.CommandRequestModels.Validations;
using Todo.Domain.ResponseModels;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class UpdateTodoRequestModel : IRequestValidateble<GenericCommandResponseModel>
    {
        private UpdateTodoRequestModelValidator _validator { get; set; }

        public UpdateTodoRequestModel()
        {
            _validator = new UpdateTodoRequestModelValidator();
        }

        public UpdateTodoRequestModel(Guid id, string title, string user)
        {
            
            Title = title;
            User = user;
            Id = id;
            _validator = new UpdateTodoRequestModelValidator();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public ValidationResult Validate() => _validator.Validate(this);
    }
}