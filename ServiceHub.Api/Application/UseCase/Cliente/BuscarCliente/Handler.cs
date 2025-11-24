using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cliente.BuscarCliente;

public class Handler : IRequestHandler<Query, Result<Response>>
{

    private readonly IClienteRepository _clienteRepository;
    
    public Handler(IClienteRepository clienteRepository)
    {
        
        _clienteRepository = clienteRepository;
    }
    
    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        try
        {
            var Clientes = await _clienteRepository.EncontrarClienteAsync(request.pagina,
                request.tamanhoPagina);

            return Result.Ok(new Response(Clientes));
        }
        catch (Exception ex)
        {
            return Result.Fail<Response>("E499", $"Houve um erro ao carregar Clientes {ex.Message}");
        }
    }
}