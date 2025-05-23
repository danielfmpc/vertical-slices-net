using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.ToDos.Commands;

public record struct CreateToDoCommand(string Title) : IRequest<Result<Guid>>;

public class CreateToDoCommandHandler(ToDoRepository repository) : IRequestHandler<CreateToDoCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        ToDo toDo = new ToDo(request.Title);

        await repository.AddAsync(toDo);

        return Result.Ok(toDo.Id);
    }
}