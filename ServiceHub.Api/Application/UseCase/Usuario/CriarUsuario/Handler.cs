using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Application.UseCase.Usuario.CriarUsuario;

public class Handler  : IRequestHandler<Command, Result>
{

    private readonly IUsuarioRepository _repository;

    public Handler(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken = default(CancellationToken))
    {
        
        if(await _repository.UsuarioExisteAsync(request.email)) return Result.Fail("E101", "usuario já existe");

        if(string.IsNullOrEmpty(request.nome)) return  Result.Fail("E107", "Nome do usuário não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.email)) return  Result.Fail("E108", "Email do usuário não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.telefone)) return  Result.Fail("E109", "Telefone do usuário não pode ser nulo");
        
        if(string.IsNullOrEmpty(request.senha)) return  Result.Fail("E110", "Senha do usuário não pode ser nulo");
        
        try
        {
            await _repository.CriarUsuarioAsync(new ApplicationUser()
            {
                Name = request.nome,
                UserName = request.email,
                Email = request.email,
                PhoneNumber = request.telefone
            }, request.senha);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            
                    
                    return Result.Fail("E199",  $"Houve um erro inesperado ao criar usuário: \n{ex.Message}");
                    
                  
            
        }
    }

}