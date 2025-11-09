using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;

namespace ServiceHub.Api.Repository;

public class CidadeRepository : ICidadeRepository
{
    
    private readonly Context _context;

    public CidadeRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Cidade?> EncontrarCidadePeloIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Cidade?> EncontrarCidadePeloNomeAsync(string nome)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExisteCidadeAsync(string ibge)
    {
        var cidade = await _context.Cidade.FirstOrDefaultAsync(c => c.Ibge == ibge);
        
        return cidade != null;
    }

    public async Task CriarCidadeAsync(Cidade cidade)
    {
        if (cidade != null) await _context.Cidade.AddAsync(cidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarCidadeAsync(Cidade cidade)
    {
        throw new NotImplementedException();
    }

    public async Task RemoverCidadeAsync(string id)
    {
        throw new NotImplementedException();
    }
}