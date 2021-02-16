using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.RequestModels.CommandRequestModels;
using Todo.Domain.ResponseModels;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetAllAsync(user);
        }

        [Route("done")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllDoneAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetAllDoneAsync(user);
        }

        [Route("undone")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetAllUndoneAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetAllUndoneAsync(user);
        }

        [Route("done/today")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetDoneForTodayAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetByPeriodAsync(
                user,
                DateTime.Now.Date,
                true
            );
        }

        [Route("undone/today")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetInactiveForTodayAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetByPeriodAsync(
                user,
                DateTime.Now.Date,
                false
            );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetDoneForTomorrowAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetByPeriodAsync(
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetUndoneForTomorrowAsync([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await repository.GetByPeriodAsync(
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResponseModel> Create([FromBody]CreateTodoRequestModel command, [FromServices]IMediator mediator)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await mediator.Send(command);
        }

        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResponseModel> UpdateAsync([FromBody]UpdateTodoRequestModel command, [FromServices]IMediator mediator)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await mediator.Send(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public async Task<GenericCommandResponseModel> MarkAsDoneAsync([FromBody]MarkTodoAsDoneRequestModel command, [FromServices]IMediator mediator)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await mediator.Send(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public async Task<GenericCommandResponseModel> MarkAsUndoneAsync([FromBody]MarkTodoAsUndoneRequestModel command, [FromServices]IMediator mediator)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return await mediator.Send(command);
        }
    }
}