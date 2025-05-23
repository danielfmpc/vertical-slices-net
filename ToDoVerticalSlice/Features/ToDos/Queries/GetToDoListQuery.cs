using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.ToDos.Queries;

public record struct GetToDoListQuery : IRequest<Result<List<ToDo>>>;

public class GetToDoListQueryHandler(ToDoRepository repository) : IRequestHandler<GetToDoListQuery, Result<List<ToDo>>>
{
    public async Task<Result<List<ToDo>>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
    {
        List<ToDo> toDos = await repository.GetAllAsync();
        
        return Result.Ok(toDos);
    }
}