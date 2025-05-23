using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoVerticalSlice.Features.ToDos.Queries;
using ToDoVerticalSlice.Features.ToDos.Commands;

namespace ToDoVerticalSlice.Features.ToDos.Controller;

public static class ToDoEndpoint
{
    public static void MapToDo(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/todos", async ([FromServices]IMediator mediator) =>
        {
            var query = new GetToDoListQuery();
            var result = await mediator.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });

        endpoints.MapGet("/todos/{id:guid}", async (Guid id, [FromServices]IMediator mediator) =>
        {
            var query = new GetToDoByIdQuery(id);
            var result = await mediator.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });

        endpoints.MapPost("/todos", async ([FromBody]CreateToDoCommand command, [FromServices]IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });

        endpoints.MapPut("/todos/title", async ([FromBody]UpdateTitleToDoCommand command, [FromServices]IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
        
        endpoints.MapPut("/todos/done", async ([FromBody]UpdateDoneToDoCommand command, [FromServices]IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
    }
}