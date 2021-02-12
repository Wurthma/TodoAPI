using System;

namespace Todo.Domain.RequestModels.CommandRequestModels
{
    public class CreateTodoRequestModel
    {
        public CreateTodoRequestModel(){ }

        public CreateTodoRequestModel(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
    }
}