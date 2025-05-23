using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.Produtos.Commands;

public record struct DeleteProdutoCommand(Guid Id) : IRequest<Result>;

public class DeleteProdutoCommandHandler(ProdutoRepository repository) : IRequestHandler<DeleteProdutoCommand, Result>
{
    public async Task<Result> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
    {
        Produto produto = await repository.GetByIdAsync(request.Id);
        
        if (produto == null) return Result.Fail("Produto nao encontrado");
        
        produto.Delete();
        
        await repository.DeleteAsync(produto);
        
        return Result.Ok();
    }
}