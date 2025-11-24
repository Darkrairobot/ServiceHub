using MediatR;
using Microsoft.AspNetCore.Authorization;

using CriarServicoCommand = ServiceHub.Api.Application.UseCase.Servico.CriarServico.Command;
using AtualizarServicoCommand = ServiceHub.Api.Application.UseCase.Servico.AtualizarServico.Command;
using RemoverServicoCommand = ServiceHub.Api.Application.UseCase.Servico.RemoverServico.Command;
using AtualizarServicoRequest = ServiceHub.Api.Application.UseCase.Servico.AtualizarServico.Request;
using BuscarServicoQuery = ServiceHub.Api.Application.UseCase.Servico.BuscarServico.Query;

namespace ServiceHub.Api.Endpoints;

public static class ServicoEndpoint
{

    public static RouteGroupBuilder AddServicoEndpoint(this RouteGroupBuilder group)
    {
        
        group.MapPost("criar", async (CriarServicoCommand command, ISender sender) =>
        {
            
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        }).WithDescription("Criar Servico");
        
        group.MapPatch("atualizar/{id}", async (string id, AtualizarServicoRequest request, ISender sender) =>
        {
            
            var result = await sender.Send(new AtualizarServicoCommand(id, request.nome, request.descricao, request.valor));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        }).WithDescription("Atualizar Servico");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverServicoCommand(id));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Servico");

        group.MapGet("buscar", async ([AsParameters] BuscarServicoQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        });
        
        group.RequireAuthorization();
        
        return group;
    }
    
}