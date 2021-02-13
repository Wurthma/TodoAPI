using System;
using MediatR;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class MarkTodoAsDoneRequestModel : IRequest
    {
        public MarkTodoAsDoneRequestModel(){}
        
        public MarkTodoAsDoneRequestModel(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
    }
}