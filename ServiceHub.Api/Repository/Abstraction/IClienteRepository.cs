using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IClienteRepository
{

    Task<Cliente?> EncontrarClientePeloIdAsync(string id);
    
    Task<bool> ClienteExisteAsync(string cpf_cnpj);
    
    Task<List<Cliente>> EncontrarClienteAsync(string? nome, string? email, string? telefone, int pagina = 1,  int tamanhoPagina = 10);
    
    Task CriarClienteAsync(Cliente cliente);
    
    Task AtualizarClienteAsync(Cliente cliente);
    
    Task RemoverClienteAsync(Cliente cliente);
    
}