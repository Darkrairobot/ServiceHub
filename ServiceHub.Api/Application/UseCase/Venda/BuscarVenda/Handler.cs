using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Venda.BuscarVenda;

public class Handler : IRequestHandler<Query, Result<Response>>
{

    private readonly IVendaRepository _repository;
    
    public Handler(IVendaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        try
        {
            var venda = await _repository.EncontrarVendaAsync(request.pagina, request.paginaTamanho);
            return Result.Ok(new Response(venda));
        }
        catch (Exception ex)
        {
            return Result.Fail<Response>("E699", $"Houve um erro ao carregar vendas: {ex.Message}");
        }
    }
}