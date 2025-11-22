using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IClienteRepository _clienteRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Handler(IClienteRepository clienteRepository,  IHttpContextAccessor httpContextAccessor)
    {
        _clienteRepository = clienteRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _clienteRepository.EncontrarClientePeloIdAsync(request.id_cliente);
            if (cliente == null) return Result.Fail("E402", "Cliente não existe");
            if (cliente.Id_Usuario != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Result.Fail("E403", "somente quem criou o cliente pode atualizar");
            
            
            cliente.Atualizar(request.nome,
                request.cpf_cnpj,
                request.email,
                request.telefone,
                request.endereco,
                request.complemento,
                request.numero,
                request.cep,
                request.bairro,
                request.id_cidade);
            
            await _clienteRepository.AtualizarClienteAsync(cliente);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E499", $"Houve um erro ao atualizar cliente {ex.Message}");
        }
    }
}