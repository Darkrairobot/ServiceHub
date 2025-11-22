using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Repository;

public class CidadeRepository : ICidadeRepository
{
    
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CidadeRepository(Context context,  IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Cidade?> EncontrarCidadePeloIdAsync(string id)
    {
        return await _context.Cidade.Where(c => c.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Cidade>> EncontrarCidadeAsync(string? nome = null, string? ibge = null, string? uf = null, int pagina = 1, int tamanhoPagina = 10)
    {
        var query =  _context.Cidade.AsQueryable();
        
        query = query.Where(c => c.Id_Usuario ==  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        if(!string.IsNullOrEmpty(nome)) query = query.Where(c => c.Nome == nome);
        if(!string.IsNullOrEmpty(ibge)) query = query.Where(c => c.Ibge == ibge);
        if(!string.IsNullOrEmpty(uf)) query = query.Where(c => c.Uf == uf);
        
        return  await query.Skip(pagina - 1).Take(tamanhoPagina).ToListAsync();
        
    }

    public async Task<bool> ExisteCidadeAsync(string ibge)
    {
        
        var userId = _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(ClaimTypes.NameIdentifier)?
            .Value;
        
        var cidade = await _context.Cidade
            .FirstOrDefaultAsync(c => c.Id_Usuario == userId && c.Ibge == ibge);
        
        return cidade != null;
    }

    public async Task CriarCidadeAsync(Cidade cidade)
    {
        if (cidade != null) await _context.Cidade.AddAsync(cidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarCidadeAsync(Cidade cidade)
    {
        _context.Cidade.Update(cidade);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverCidadeAsync(Cidade cidade)
    {
        _context.Cidade.Remove(cidade);
        await _context.SaveChangesAsync();
    }
}