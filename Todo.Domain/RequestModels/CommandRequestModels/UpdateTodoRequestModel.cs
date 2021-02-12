using System;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class UpdateTodoRequestModel
    {
        public UpdateTodoRequestModel(){ }

        public UpdateTodoRequestModel(Guid id, string title, string user)
        {
            
            Title = title;
            User = user;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
    }
}