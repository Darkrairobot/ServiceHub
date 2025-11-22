using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cliente.RemoverCliente;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IClienteRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Handler(IClienteRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _repository.EncontrarClientePeloIdAsync(request.id_cliente);
            if (cliente == null) return Result.Fail("E402", "Cliente não existe");
            if(cliente.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) return Result.Fail("E403", "somente quem criou o cliente pode remover");

            await _repository.RemoverClienteAsync(cliente);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E499", $"Houve um erro ao remover cliente {ex.Message}");
        }
    }
}