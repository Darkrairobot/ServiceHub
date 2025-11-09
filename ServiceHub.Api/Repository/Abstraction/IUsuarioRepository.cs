using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Domain.Repository;

public interface IUsuarioRepository
{
    Task<Usuario?> EncontrarUsuarioAsync(string id);
    Task<Usuario?> EncontrarUsuarioPeloEmailAsync(string email);
    
    Task<bool> UsuarioExisteAsync(string email);
        
    Task CriarUsuarioAsync(Usuario usuario, string senha);
    Task AtualizarUsuarioAsync(Usuario usuario);
    Task RemoverUsuarioAsync(string id);
}