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
        
        if(string.IsNullOrEmpty(request.nome)) return  Result.Fail("E307", "Nome da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.cnpj)) return  Result.Fail("E308", "CNPJ da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.telefone)) return  Result.Fail("E309", "Telefone da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.endereco)) return  Result.Fail("E311", "Endereco da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.complemento)) return  Result.Fail("E312", "Complemento da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.numero)) return  Result.Fail("E313", "Numero da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.bairro)) return  Result.Fail("E314", "Bairro da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.cep)) return  Result.Fail("E315", "Cep da Empresa não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.id_cidade)) return  Result.Fail("E316", "Cidade da Empresa não pode ser nulo");
        
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