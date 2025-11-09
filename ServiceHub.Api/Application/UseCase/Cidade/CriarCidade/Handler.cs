using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cidade.CriarCidade;

public class Handler : IRequestHandler<Command,Result>
{
    
    private readonly ICidadeRepository _repository;

    public Handler(ICidadeRepository repository)
    {
        _repository = repository;
    }
    

    public async Task<Result> Handle(Command command, CancellationToken cancellationToken = default(CancellationToken))
    {

        try
        {

            if (await _repository.ExisteCidadeAsync(command.ibge)) return Result.Fail("E201", "Já existe uma cidade com esse código Ibge");

            _repository.CriarCidadeAsync(new Domain.Entities.Cidade(command.nome, command.uf, command.cep,
                command.ibge));
            
            return Result.Ok();
            
        }
        catch (Exception ex)
        {
               return Result.Fail("E299", $"Houve um erro ao criar o Cidade: \n{ex.Message}");
        }
    }
    
}