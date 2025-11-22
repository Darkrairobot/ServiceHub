using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Repository;

public class ServicoRepository :  IServicoRepository
{
    
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServicoRepository(Context context,  IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Servico?> EncontrarServicoPeloIdAsync(string id)
    {
        return await _context.Servico.Where(s => s.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CriarServicoAsync(Servico servico)
    {
        await _context.Servico.AddAsync(servico);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Servico>> EncontrarServicoAsync(string id_usuario, string? nome,  string? descricao, string? valor, int  pagina = 1,  int tamanhoPagina = 10)
    {
        var query = _context.Servico.AsQueryable();
        
        query = query.Where(c => c.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        if(!string.IsNullOrEmpty(id_usuario)) query = query.Where(s => s.Id_Usuario == id_usuario);
        if(!string.IsNullOrEmpty(nome)) query = query.Where(s => s.Nome == nome);
        if(!string.IsNullOrEmpty(descricao)) query = query.Where(s => s.Descricao == descricao);

        
        
        return await query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();

    }

    public async Task AtualizarServicoAsync(Servico servico)
    {
        _context.Servico.Update(servico);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverServicoAsync(Servico servico)
    {
        _context.Servico.Remove(servico);
        await _context.SaveChangesAsync();
    }
}