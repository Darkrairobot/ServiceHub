using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IEmpresaRepository
{
    
    Task<Empresa?> EncontrarEmpresaPeloIdAsync(string id);
    
    Task<List<Empresa>> EncontrarEmpresaAsync(string? nome, string? cnpj, string? telefone, int pagina, int tamanhoPagina);
    
    Task<bool> EmpresaExisteAsync(string cnpj);
    
    Task CriarEmpresaAsync(Empresa empresa);
    
    Task AtualizarEmpresaAsync(Empresa empresa);
    
    Task DeletarEmpresaAsync(Empresa empresa);
    
}