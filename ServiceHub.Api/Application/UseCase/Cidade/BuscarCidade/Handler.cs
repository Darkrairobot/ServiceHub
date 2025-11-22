using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cidade.BuscarCidade;

public class Handler : IRequestHandler<Query, Result<Response>>
{
    
    private readonly ICidadeRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Handler(ICidadeRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        try
        {
            var cidades = await _repository.EncontrarCidadeAsync(request.nome, request.ibge, request.uf, request.pagina,
                request.tamanhoPagina);

            return Result.Ok(new Response(cidades));
        }
        catch (Exception ex)
        {
            return Result.Fail<Response>("E299", $"Houve um erro ao carregar cidades {ex.Message}");
        }
    }
}