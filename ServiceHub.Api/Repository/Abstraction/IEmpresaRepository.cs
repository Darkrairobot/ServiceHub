using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IEmpresaRepository
{
    
    Task<Empresa?> EncontrarEmpresaPeloIdAsync(string id);
    
    Task<Empresa?> EncontrarEmpresaPeloCnpjAsync(string cnpj);
    
    Task<bool> EmpresaExisteAsync(string cnpj);
    
    Task CriarEmpresaAsync(Empresa empresa);
    
    Task AtualizarEmpresaAsync(Empresa empresa);
    
    Task DeletarEmpresaAsync(string id);
    
}