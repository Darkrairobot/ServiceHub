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
    
    private readonly UserManager<ApplicationUser> _userManager;

    public UsuarioRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser?> EncontrarUsuarioPeloIdAsync(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<bool> UsuarioExisteAsync(string email)
    {
        var usuario = await _userManager.FindByEmailAsync(email);
        return usuario != null;
    }

    public async Task CriarUsuarioAsync(ApplicationUser usuario, string senha)
    {
        var result = await _userManager.CreateAsync(usuario, senha);
        if(!result.Succeeded) throw new Exception(result.Errors.First().Description);
    }

    public async Task AtualizarUsuarioAsync(ApplicationUser usuario)
    {
        await  _userManager.UpdateAsync(usuario);
    }
    

    public async Task RemoverUsuarioAsync(ApplicationUser usuario)
    {
        await _userManager.DeleteAsync(usuario);
    }
}