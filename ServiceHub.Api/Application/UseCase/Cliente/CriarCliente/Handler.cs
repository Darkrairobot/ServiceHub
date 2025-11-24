using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Cliente.CriarCliente;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IClienteRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICidadeRepository _cidadeRepository;

    public Handler(IClienteRepository repository,  IHttpContextAccessor httpContextAccessor,  ICidadeRepository cidadeRepository)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        _cidadeRepository = cidadeRepository;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        
        if(string.IsNullOrEmpty(request.nome)) return  Result.Fail("E407", "Nome do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.email)) return  Result.Fail("E408", "Email do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.telefone)) return  Result.Fail("E409", "Telefone do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.cpf_cnpj)) return  Result.Fail("E410", "CPF ou CNPJ do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.endereco)) return  Result.Fail("E411", "Endereco do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.complemento)) return  Result.Fail("E412", "Complemento do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.numero)) return  Result.Fail("E413", "Numero do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.bairro)) return  Result.Fail("E414", "Bairro do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.cep)) return  Result.Fail("E415", "Cep do Cliente não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.id_cidade)) return  Result.Fail("E416", "Cidade do Cliente não pode ser nulo");
        
        try
        {
            
            var id_usuario = _httpContextAccessor
                .HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;
            
            if(await _repository.ClienteExisteAsync(request.cpf_cnpj)) return Result.Fail("E401", "Cliente já existe com esse CPF/CNPJ");
            
            var cidade = await _cidadeRepository.EncontrarCidadePeloIdAsync(request.id_cidade);
            if(cidade == null)  return  Result.Fail("E417", "Cidade não encontrado");
            
            
            await _repository.CriarClienteAsync(new Domain.Entities.Cliente(id_usuario,
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
            return Result.Fail("E499", $"Houve um erro ao criar cliente {ex.InnerException.Message}");
        }
    }
}