using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Venda.CriarVenda;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IVendaRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Handler(IVendaRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {

        try
        {
            var id_usuario = _httpContextAccessor
                .HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;

            var venda = new Domain.Entities.Venda(id_usuario, request.id_cliente, request.id_servico, request.endereco,
                request.complemento, request.numero, request.cep, request.bairro, request.id_cidade);

            await _repository.CriarVendaAsync(venda);
            
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E699", $"Houve um erro ao criar Venda: {ex.Message}");
        }
    }
}