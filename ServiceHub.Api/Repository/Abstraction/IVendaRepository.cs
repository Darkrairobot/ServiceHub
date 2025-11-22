using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IVendaRepository
{

    Task <Venda?> EncontrarVendaPeloIdAsync(string id);
    
    Task<List<Venda>> EncontrarVendaAsync(int pagina = 1, int tamanhoPagina = 10);
    
    Task CriarVendaAsync(Venda venda);
    
    Task AtualizarVendaAsync(Venda venda);
    
    Task RemoverVendaAsync(Venda venda);

}