using Todo.Domain.Interfaces.ICommandHandlers;

namespace Todo.Domain.ResponseModels
{
    public class GenericCommandResponse : IGenericCommandResponse
    {
        public GenericCommandResponse(){}

        public GenericCommandResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}