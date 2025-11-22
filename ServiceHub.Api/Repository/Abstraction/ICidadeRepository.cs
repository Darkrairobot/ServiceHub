using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface ICidadeRepository
{
    
    Task<Cidade? > EncontrarCidadePeloIdAsync(string id);
    Task<List<Cidade>> EncontrarCidadeAsync(string? nome, string? ibge, string? uf, int  pagina, int tamanhoPagina);
    
    Task<bool> ExisteCidadeAsync(string ibge);
    
    Task CriarCidadeAsync(Cidade cidade);
    
    Task AtualizarCidadeAsync(Cidade cidade);
    
    Task RemoverCidadeAsync(Cidade cidade);

}