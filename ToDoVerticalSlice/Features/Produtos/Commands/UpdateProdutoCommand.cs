using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.Produtos.Commands;

public record struct UpdateProdutoCommand(Guid Id, string Name, decimal Price) : IRequest<Result<Produto>>;

public class UpdateProdutoCommandHandler(ProdutoRepository repository) : IRequestHandler<UpdateProdutoCommand, Result<Produto>>
{
    public async Task<Result<Produto>> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await repository.GetByIdAsync(request.Id);
        
        if (produto == null) return Result.Fail("Produto nao encontrado");
        
        produto.Update(request.Name, request.Price);
        
        await repository.UpdateAsync(produto);

        return Result.Ok(produto);
    }
}