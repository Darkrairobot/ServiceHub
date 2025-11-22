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
            switch (ex)
            {
                case ValidationException validationException:
                    
                    return Result.Fail("E102",  validationException.Message);
                    
                    break;
                
                case DbUpdateException dbUpdateException:
                    
                    return Result.Fail("E103",  dbUpdateException.InnerException.Message);
                    
                    break;
                
                default:
                    
                    return Result.Fail("E199",  $"Houve um erro inesperado ao criar usuário: \n{ex.InnerException.Message} {ex.GetType()} {ex.StackTrace}");
                    
                    break;
            }
        }
    }

}