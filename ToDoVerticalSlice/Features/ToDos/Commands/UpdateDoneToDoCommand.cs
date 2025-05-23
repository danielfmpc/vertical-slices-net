using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.ToDos.Commands;

public record struct UpdateDoneToDoCommand(Guid Id, bool Done) : IRequest<Result<ToDo>>;

public class UpdateDoneToDoCommandHandler(ToDoRepository repository) : IRequestHandler<UpdateDoneToDoCommand, Result<ToDo>>
{
    public async Task<Result<ToDo>> Handle(UpdateDoneToDoCommand request, CancellationToken cancellationToken)
    {
        ToDo todo = await repository.GetByIdAsync(request.Id);
        
        if (todo is null) return Result.Fail("ToDo not found");
        
        todo.UpdateDone(request.Done);

        await repository.UpdateAsync(todo);

        return Result.Ok(todo);
    }
}