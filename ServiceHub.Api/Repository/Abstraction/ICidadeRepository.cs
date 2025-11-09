using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface ICidadeRepository
{

    Task<Cidade?> EncontrarCidadePeloIdAsync(string id);
    
    Task<Cidade?> EncontrarCidadePeloNomeAsync(string nome);
    
    Task<bool> ExisteCidadeAsync(string ibge);
    
    Task CriarCidadeAsync(Cidade cidade);
    
    Task AtualizarCidadeAsync(Cidade cidade);
    
    Task RemoverCidadeAsync(string id);

}