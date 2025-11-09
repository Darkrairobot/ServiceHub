using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    
    private readonly Context _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UsuarioRepository(Context context,  UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public Task<Usuario?> EncontrarUsuarioAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Usuario?> EncontrarUsuarioPeloEmailAsync(string email)
    {
        return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> UsuarioExisteAsync(string email)
    {
        var usuario = _context.Usuario.FirstOrDefault(u => u.Email == email);
        return usuario is not null;
    }

    public async Task CriarUsuarioAsync(Usuario usuario, string senha)
    {
        
        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        try
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Id = usuario.Id,
                UserName = usuario.Email,
                Email = usuario.Email,
                PhoneNumber = usuario.Telefone
            }, senha);
            
            if(!result.Succeeded) throw new ValidationException(result.Errors.First().Description);
            
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public Task AtualizarUsuarioAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task RemoverUsuarioAsync(string id)
    {
        throw new NotImplementedException();
    }
}