using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Servico.BuscarServico;

public class Handler : IRequestHandler<Query, Result<Response>>
{
    
    private readonly IServicoRepository _servicoRepository;

    public Handler(IServicoRepository Repository)
    {
        _servicoRepository = Repository;
    }
    
    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        try
        {
            var Servicos = await _servicoRepository.EncontrarServicoAsync(request.pagina,
                request.tamanhoPagina);

            return Result.Ok(new Response(Servicos));
        }
        catch (Exception ex)
        {
            return Result.Fail<Response>("E599", $"Houve um erro ao carregar Servicos {ex.Message}");
        }
    }
}