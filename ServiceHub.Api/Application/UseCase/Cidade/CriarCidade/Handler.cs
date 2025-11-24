using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cidade.CriarCidade;

public class Handler : IRequestHandler<Command,Result>
{
    
    private readonly ICidadeRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(ICidadeRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    

    public async Task<Result> Handle(Command command, CancellationToken cancellationToken = default(CancellationToken))
    {

        try
        {
            
            if (await _repository.ExisteCidadeAsync(command.ibge)) return Result.Fail("E201", "Já existe uma cidade com esse código Ibge");

            if (string.IsNullOrEmpty(command.nome))
                return Result.Fail("E207", "Nome da Cidade não pode ser nulo");
            
            if (string.IsNullOrEmpty(command.uf))
                return Result.Fail("E208", "UF da Cidade não pode ser nulo");
            
            if(command.uf.Length != 2) 
                return Result.Fail("E211", "UF da Cidade deve ter 2 caracteres");
            
            
            if (string.IsNullOrEmpty(command.cep))
                return Result.Fail("E209", "Cep da Cidade não pode ser nulo");
            
            if (string.IsNullOrEmpty(command.ibge))
                return Result.Fail("E210", "Código IBGE da Cidade não pode ser nulo");
            
            await _repository.CriarCidadeAsync(new Domain.Entities.Cidade(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, command.nome, command.uf, command.cep,
                command.ibge));
            
            return Result.Ok();
            
        }
        catch (Exception ex)
        {
               return Result.Fail("E299", $"Houve um erro ao criar o Cidade: \n{ex.InnerException.Message}");
        }
    }
    
}