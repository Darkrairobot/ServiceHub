using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Repository;

public class VendaRepository : IVendaRepository
{
    
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public VendaRepository(Context context,  IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<Venda?> EncontrarVendaPeloIdAsync(string id)
    {
        return await _context.Venda.Where(v => v.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<List<Venda>> EncontrarVendaAsync(int pagina = 1, int tamanhoPagina = 10)
    {
        
        return await _context.Venda.Where(v => v.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            .Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();
    }

    public async Task CriarVendaAsync(Venda venda)
    {
        await _context.Venda.AddAsync(venda);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarVendaAsync(Venda venda)
    {
        _context.Venda.Update(venda);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverVendaAsync(Venda venda)
    {
        _context.Venda.Remove(venda);
        await _context.SaveChangesAsync();
    }
}