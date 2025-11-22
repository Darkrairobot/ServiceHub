using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cliente.CriarCliente;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IClienteRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(IClienteRepository repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        if(await _repository.ClienteExisteAsync(request.cpf_cnpj)) return Result.Fail("E401", "Cliente já existe com esse CPF/CNPJ");

        try
        {
            await _repository.CriarClienteAsync(new Domain.Entities.Cliente(_httpContextAccessor.HttpContext.User
                    .FindFirst(ClaimTypes.NameIdentifier)
                    .Value,
                request.nome,
                request.cpf_cnpj,
                request.email,
                request.telefone,
                request.endereco,
                request.complemento,
                request.numero,
                request.cep,
                request.bairro,
                request.id_cidade));
            
            return Result.Ok();
            
        }
        catch (Exception ex)
        {
            return Result.Fail("E499", $"Houve um erro ao criar cliente {ex.Message}");
        }
    }
}