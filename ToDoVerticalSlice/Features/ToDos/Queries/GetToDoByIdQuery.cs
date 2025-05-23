using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.ToDos.Queries;

public record struct GetToDoByIdQuery(Guid Id) : IRequest<Result<ToDo>>;
    
public class GetToDoByIdQueryHandle(ToDoRepository repository) : IRequestHandler<GetToDoByIdQuery, Result<ToDo>>
{
    public async Task<Result<ToDo>> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
    {
        ToDo todo = await repository.GetByIdAsync(request.Id);

        if (todo is null) return Result.Fail("ToDo not found");

        return Result.Ok(todo);
    }
}