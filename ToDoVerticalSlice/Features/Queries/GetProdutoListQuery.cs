using FluentResults;
using MediatR;
using ToDoVerticalSlice.Domain;

namespace ToDoVerticalSlice.Features.Queries;

public record struct GetProdutoListQuery : IRequest<Result<List<Produto>>>;

public class GetProdutoListQueryHandler(ProdutoRepository repository)
    : IRequestHandler<GetProdutoListQuery, Result<List<Produto>>>
{
    public async Task<Result<List<Produto>>> Handle(GetProdutoListQuery request, CancellationToken cancellationToken)
    {
        var produtos = await repository.GetAllAsync();
        
        return Result.Ok(produtos);
    }
}