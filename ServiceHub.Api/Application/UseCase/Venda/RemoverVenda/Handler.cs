using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Venda.RemoverVenda;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IVendaRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(IVendaRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            var venda = await _repository.EncontrarVendaPeloIdAsync(request.id_venda);
            if (venda == null) return Result.Fail("E602", "venda não existe");
            if (venda.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Result.Fail("E603", "somente quem criou a venda pode Remover");

            await _repository.RemoverVendaAsync(venda);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E399", $"Houve um erro ao remover venda {ex.Message}");
        }
    }
}