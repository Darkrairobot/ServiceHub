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

            _repository.CriarCidadeAsync(new Domain.Entities.Cidade(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, command.nome, command.uf, command.cep,
                command.ibge));
            
            return Result.Ok();
            
        }
        catch (Exception ex)
        {
               return Result.Fail("E299", $"Houve um erro ao criar o Cidade: \n{ex.Message}");
        }
    }
    
}