using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Domain.Repository;

public class EmpresaRepository : IEmpresaRepository
{
    
    private readonly Context _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmpresaRepository(Context context,  IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Empresa?> EncontrarEmpresaPeloIdAsync(string id)
    {
        return await _context.Empresa.Where(e =>
            e.Id_Usuario == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Empresa>> EncontrarEmpresaAsync(string? nome, string? cnpj,string? telefone, int pagina = 1, int tamanhoPagina = 10)
    {
        var query =  _context.Empresa.AsQueryable();
        
        query  = query.Where(e => e.Id_Usuario ==  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        if(!string.IsNullOrEmpty(nome)) query = query.Where(e => e.Nome == nome);
        if(!string.IsNullOrEmpty(cnpj)) query = query.Where(e => e.Cnpj == cnpj);
        if(!string.IsNullOrEmpty(telefone)) query = query.Where(e => e.Telefone == telefone);
        
        return await query.ToListAsync();
        
    }

    public async Task<bool> EmpresaExisteAsync(string cnpj)
    {
        var empresa = await _context.Empresa.FirstOrDefaultAsync(e => e.Cnpj == cnpj);
        return empresa != null;
    }

    public async Task CriarEmpresaAsync(Empresa empresa)
    {
        await _context.Empresa.AddAsync(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarEmpresaAsync(Empresa empresa)
    {
        _context.Empresa.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarEmpresaAsync(Empresa empresa)
    {
        _context.Empresa.Remove(empresa);
        await _context.SaveChangesAsync();
    }
}