using MediatR;
using Microsoft.AspNetCore.Identity;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure.Entity;
using ServiceHub.Api.Service;

namespace ServiceHub.Api.Application.UseCase.Usuario.RealizarLogin;

public class Handler : IRequestHandler<Command, Result<Response>>
{
    
    private readonly TokenService _tokenService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Handler(TokenService tokenService,  IUsuarioRepository usuarioRepository,  SignInManager<ApplicationUser> signInManager)
    {
        _tokenService = tokenService;
        _usuarioRepository = usuarioRepository;
        _signInManager = signInManager;
    }
    
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _usuarioRepository.UsuarioExisteAsync(request.email))
                return Result.Fail<Response>("E401", "Usuário não existe");

            var usuario = await _usuarioRepository.EncontrarUsuarioPeloEmailAsync(request.email);

            var result =
                await _signInManager.PasswordSignInAsync(request.email, request.senha, false, lockoutOnFailure: false);

            if (!result.Succeeded) return Result.Fail<Response>("E402", "Email ou senha incorreto");

            var token = await _tokenService.GerarToken(usuario.Id, usuario.Email, usuario.Nome);

            return Result.Ok<Response>(new Response(token));
        }
        catch (Exception ex)
        {
            return Result.Fail<Response>("E499", $"houve um erro inesperado ao realizar login: \n{ex.Message}");
        }
    }
}