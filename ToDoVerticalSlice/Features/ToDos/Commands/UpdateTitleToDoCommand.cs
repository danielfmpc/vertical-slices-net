using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.ToDos.Commands;

public record struct UpdateTitleToDoCommand(Guid Id, string Title) : IRequest<Result<ToDo>>;

public class UpdateTitleToDoCommandHandler(ToDoRepository repository) : IRequestHandler<UpdateTitleToDoCommand, Result<ToDo>>
{
    public async Task<Result<ToDo>> Handle(UpdateTitleToDoCommand request, CancellationToken cancellationToken)
    {
        ToDo todo = await repository.GetByIdAsync(request.Id);
        
        if (todo is null) return Result.Fail("ToDo not found");
        
        todo.UpdateTitle(request.Title);

        await repository.UpdateAsync(todo);

        return Result.Ok(todo);
    }
}