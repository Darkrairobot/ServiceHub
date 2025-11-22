using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Servico.AtualizarServico;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IServicoRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(IServicoRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        
        try
        {
            var servico = await _repository.EncontrarServicoPeloIdAsync(request.id_servico);
            if (servico == null) return Result.Fail("E502", "Servico não existe");
            if (servico.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Result.Fail("E503", "somente quem criou a Servico pode atualizar");

            servico.Atualizar(request.nome, request.descricao, request.valor);

            await _repository.AtualizarServicoAsync(servico);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E599", $"Houve um erro ao atualizar servico {ex.Message}");
        }
    }
}