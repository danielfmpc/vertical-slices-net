using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.Produtos.Queries;

public record struct GetProdutoPorIdQuery(Guid Id) : IRequest<Result<Produto>>;


public class GetProdutoPorIdQueryHandler(ProdutoRepository repository) : IRequestHandler<GetProdutoPorIdQuery, Result<Produto>>
{
    public async Task<Result<Produto>> Handle(GetProdutoPorIdQuery request, CancellationToken cancellationToken)
    {
        var produto = await repository.GetByIdAsync(request.Id);
        
        if (produto == null) return Result.Fail("Produto nao encontrado");
        
        return Result.Ok(produto);
    }
}