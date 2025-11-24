using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IServicoRepository
{

    Task<Servico?> EncontrarServicoPeloIdAsync(string id);
    
    Task CriarServicoAsync(Servico servico);

    Task<List<Servico>> EncontrarServicoAsync(int pagina = 1,  int tamanhoPagina = 10);
    
    Task AtualizarServicoAsync(Servico servico);
    
    Task RemoverServicoAsync(Servico servico);

}