using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    

    public ClienteRepository(Context context,  IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Cliente?> EncontrarClientePeloIdAsync(string id)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id_Usuario == userId && c.Id == id);
    }

    public async Task<bool> ClienteExisteAsync(string cpf_cnpj)
    {
        var usuario = await _context.Cliente.FirstOrDefaultAsync(c => c.Cpf_cnpj == cpf_cnpj);
        return usuario != null;
    }

    public async Task<List<Cliente>?> EncontrarClienteAsync(int pagina = 1,
        int tamanhoPagina = 10)
    {
        var query = _context.Cliente.AsQueryable();
        
        query = query.Where(c => c.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        return await query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();
        
    }

    public async Task CriarClienteAsync(Cliente cliente)
    {
        await _context.Cliente.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarClienteAsync(Cliente cliente)
    {
        _context.Cliente.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverClienteAsync(Cliente cliente)
    {
        _context.Cliente.Remove(cliente);
        await _context.SaveChangesAsync();
    }
}