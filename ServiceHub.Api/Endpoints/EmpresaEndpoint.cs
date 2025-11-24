using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ServiceHub.Api.Endpoints;

using CriarEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.CriarEmpresa.Command;
using AtualizarEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa.Command;
using RemoverEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.RemoverEmpresa.Command;
using AtualizarEmpresaRequest = ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa.Request;


public static class EmpresaEndpoint
{

    
    public static RouteGroupBuilder AddEmpresaEndpoint(this RouteGroupBuilder group)
    {
        
        group.MapPost("criar", async (CriarEmpresaCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Criar Empresa");

        group.MapPatch("atualizar/{id}", async (string id, AtualizarEmpresaRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AtualizarEmpresaCommand(id, request.nome, request.cnpj, request.telefone, request.endereco, request.complemento, request.bairro, request.numero, request.cep, request.id_cidade));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Atualizar Empresa");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverEmpresaCommand(id) );
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Empresa");
        
        group.RequireAuthorization();
        
        return group;
    }
    
}