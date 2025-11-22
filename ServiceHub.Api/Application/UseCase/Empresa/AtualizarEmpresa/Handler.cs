using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IEmpresaRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Handler(IEmpresaRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository  = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {

        try
        {
            var empresa = await _repository.EncontrarEmpresaPeloIdAsync(request.id_empresa);
            if (empresa == null) return Result.Fail("E302", "Empresa não existe");
            if(empresa.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) return Result.Fail("E403", "somente quem criou a Empresa pode atualizar");

            empresa.Atualizar(request.nome, request.cnpj, request.telefone, request.endereco,  request.complemento, request.bairro, request.numero, request.cep, request.id_cidade);
            await  _repository.AtualizarEmpresaAsync(empresa);
            return Result.Ok();
            
        }
        catch (Exception ex)
        {
            return Result.Fail("E399", $"Houve um erro ao atualizar empresa {ex.Message}");
        }
    }
}