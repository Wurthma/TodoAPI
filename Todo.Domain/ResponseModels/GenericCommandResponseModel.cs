using Todo.Domain.Interfaces.ICommandHandlers;

namespace Todo.Domain.ResponseModels
{
    public class GenericCommandResponseModel : IGenericCommandResponse
    {
        public GenericCommandResponseModel(){}

        public GenericCommandResponseModel(bool success, string message, object data)
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