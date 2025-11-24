using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Servico.CriarServico;

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
        
        if(string.IsNullOrEmpty(request.nome)) return  Result.Fail("E507", "Nome do Serviço não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.descricao)) return  Result.Fail("E508", "Descrição do Serviço não pode ser nulo");
        
        try
        {
            await _repository.CriarServicoAsync(new Domain.Entities.Servico(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, request.nome, request.descricao, request.valor));
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E599", $"Houve um erro ao criar servico: {ex.InnerException.Message}");
        }
    }
}