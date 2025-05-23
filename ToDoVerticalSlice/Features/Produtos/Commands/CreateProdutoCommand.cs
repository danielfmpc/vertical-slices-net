using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.Produtos.Commands;

public record struct CreateProdutoCommand(string Name, decimal Price) : IRequest<Result<Guid>>;

public class CreateProdutoCommandHandler(ProdutoRepository repository) : IRequestHandler<CreateProdutoCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto(request.Name, request.Price);
        
        await repository.AddAsync(produto);
        
        return Result.Ok(produto.Id);
    }
}
