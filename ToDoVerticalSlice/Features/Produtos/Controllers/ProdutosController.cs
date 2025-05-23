using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoVerticalSlice.Features.Produtos.Commands;
using ToDoVerticalSlice.Features.Produtos.Queries;

namespace ToDoVerticalSlice.Features.Produtos.Controllers;

public static class ProductsEndpoint
{
    public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/produtos", async ([FromServices]IMediator mediator) =>
        {
            var query = new GetProdutoListQuery();
        
            var result = await mediator.Send(query);
        
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
        endpoints.MapGet("/produtos/{id:guid}", async (Guid id, [FromServices]IMediator mediator) =>
        {
            var query = new GetProdutoPorIdQuery(id);
        
            var result = await mediator.Send(query);
        
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
        endpoints.MapPost("/produtos", async ([FromBody]CreateProdutoCommand command, [FromServices]IMediator mediator) =>
        {
            var result = await mediator.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
        endpoints.MapPut("/produtos", async ([FromBody]UpdateProdutoCommand command, [FromServices]IMediator mediator) =>
        {
            var result = await mediator.Send(command);
        
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
        endpoints.MapDelete("/produtos/{id:guid}", async (Guid id, [FromServices]IMediator mediator) =>
        {
            var command = new DeleteProdutoCommand(id);

            var result = await mediator.Send(command);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        });
        return endpoints;
    }
}