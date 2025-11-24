using System.Security.Claims;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;

namespace ServiceHub.Api.Application.UseCase.Venda.CriarVenda;

public class Handler : IRequestHandler<Command, Result>
{
    
    private readonly IVendaRepository _repository;
    private readonly IServicoRepository _servicoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICidadeRepository _cidadeRepository;
    private readonly IClienteRepository _clienteRepository;
    
    public Handler(IVendaRepository repository,  IHttpContextAccessor httpContextAccessor,  IServicoRepository servicoRepository,  ICidadeRepository cidadeRepository,  IClienteRepository clienteRepository)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        _servicoRepository = servicoRepository;
        _cidadeRepository = cidadeRepository;
        _clienteRepository = clienteRepository;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        
        if(string.IsNullOrEmpty(request.id_cliente)) return  Result.Fail("E607", "Cliente da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.id_servico)) return  Result.Fail("E608", "Serviço da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.cep)) return  Result.Fail("E609", "Cep da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.id_cidade)) return  Result.Fail("E610", "Cidade da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.endereco)) return  Result.Fail("E611", "Endereco da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.complemento)) return  Result.Fail("E612", "Complemento da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.numero)) return  Result.Fail("E613", "Numero da venda não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.bairro)) return  Result.Fail("E614", "Bairro da venda não pode ser nulo");
        
        try
        {
            var id_usuario = _httpContextAccessor
                .HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;
            
            var cliente = await _clienteRepository.EncontrarClientePeloIdAsync(request.id_cliente);
            
            var cidade = await _cidadeRepository.EncontrarCidadePeloIdAsync(request.id_cidade);
            
            var servico = await _servicoRepository.EncontrarServicoPeloIdAsync(request.id_servico);
            
            if(cidade == null) return  Result.Fail("E616", "cidade não encontrado");
            
            if(cliente == null) return  Result.Fail("E618", "Cliente não encontrado");
            
            if(servico == null) return  Result.Fail("E620", "Servico não encontrado");
            
            var venda = new Domain.Entities.Venda(id_usuario, request.id_cliente, request.id_servico, request.endereco,
                request.complemento, request.numero, request.cep, request.bairro, request.id_cidade);

            await _repository.CriarVendaAsync(venda);
            
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail("E699", $"Houve um erro ao criar Venda: {ex.InnerException.Message}");
        }
    }
}