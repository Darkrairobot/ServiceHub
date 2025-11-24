using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cidade.DeletarCidade;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly ICidadeRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Handler(ICidadeRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            var cidade = await _repository.EncontrarCidadePeloIdAsync(request.id_cidade);
            if (cidade == null) return Result.Fail("E202", "Cidade não existe");
            if(cidade.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) return Result.Fail("E403", "somente quem criou a cidade pode remover");
            
            await _repository.RemoverCidadeAsync(cidade);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E299", $"Houve um erro ao excluir o Cidade: {ex.InnerException.Message}");
        }
    }
    
}