using System;
using FluentValidation.Results;
using Todo.Domain.Interfaces.ICommandHandlers;
using Todo.Domain.RequestModels.CommandRequestModels.Validations;
using Todo.Domain.ResponseModels;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class CreateTodoRequestModel : IRequestValidateble<GenericCommandResponseModel>
    {
        private CreateTodoRequestModelValidator _validator { get; set; }

        public CreateTodoRequestModel()
        {
            _validator = new CreateTodoRequestModelValidator();
        }

        public CreateTodoRequestModel(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }
    }
}