using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Empresa.CriarEmpresa;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IEmpresaRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(IEmpresaRepository empresaRepository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = empresaRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    public async Task<Result> Handle(Command request,CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            
            var usuario = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            
            if (await _repository.EmpresaExisteAsync(request.cnpj))
                return Result.Fail("E301", "Empresa com esse cnpj já existe");
            
            await _repository.CriarEmpresaAsync(new Domain.Entities.Empresa(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, request.nome,  request.cnpj, request.telefone, request.endereco, request.complemento, request.bairro, request.numero, request.id_cidade, request.cep));
            
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E399", $"Houve um erro ao criar o empresa {ex.InnerException.Message} {_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value}");
        }
    }
}