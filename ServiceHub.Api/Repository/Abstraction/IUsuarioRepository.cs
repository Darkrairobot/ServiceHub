using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Repository;

public interface IUsuarioRepository
{
    
    Task<ApplicationUser?> EncontrarUsuarioPeloIdAsync(string id);
    Task<bool> UsuarioExisteAsync(string email);
    Task CriarUsuarioAsync(ApplicationUser usuario, string senha);
    Task AtualizarUsuarioAsync(ApplicationUser usuario);
    Task RemoverUsuarioAsync(ApplicationUser usuario);
}