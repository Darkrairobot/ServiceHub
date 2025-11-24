using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Repository;

namespace ServiceHub.Api.Endpoints;

using CriarCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.CriarCidade.Command;
using AtualizarCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.AtualizarCidade.Command;
using RemoverCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.DeletarCidade.Command;
using BuscarCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.BuscarCidade.Query;
using AtualizarCidadeRequest = ServiceHub.Api.Application.UseCase.Cidade.AtualizarCidade.Request;


public static class CidadeEndpoint
{

    public static RouteGroupBuilder AddCidadeEndpoint(this RouteGroupBuilder group)
    {
        
        group.MapPost("criar", async (CriarCidadeCommand command, ISender sender) =>
        {
            
            var result = await sender.Send(command);
            
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        }).WithDescription("Criar Cidade");

        group.MapPatch("atualizar/{id}", async (string id, AtualizarCidadeRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AtualizarCidadeCommand(id, request.nome, request.uf, request.cep, request.ibge));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Atualizar Cidade");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverCidadeCommand(id));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Cidade");

        group.MapGet("/buscar", async ([AsParameters] BuscarCidadeCommand query, ISender sender) =>
        {
            var result = await sender.Send(query);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        }).WithDescription("Buscar Cidade");

        group.RequireAuthorization();
        
        return group;
    }
    
}