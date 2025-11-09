using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Domain.Repository;

public class EmpresaRepository : IEmpresaRepository
{
    
    private readonly Context _context;

    public EmpresaRepository(Context context)
    {
        _context = context;
    }
    
    public Task<Empresa?> EncontrarEmpresaPeloIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Empresa?> EncontrarEmpresaPeloCnpjAsync(string cnpj)
    {
        throw new NotImplementedException();
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

    public Task AtualizarEmpresaAsync(Empresa empresa)
    {
        throw new NotImplementedException();
    }

    public Task DeletarEmpresaAsync(string id)
    {
        throw new NotImplementedException();
    }
}