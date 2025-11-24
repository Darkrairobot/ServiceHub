using MediatR;
using Microsoft.AspNetCore.Authorization;
using ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente;
using CriarClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.CriarCliente.Command;
using AtualizarClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente.Command;
using RemoverClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.RemoverCliente.Command;
using BuscarClienteQuery = ServiceHub.Api.Application.UseCase.Cliente.BuscarCliente.Query;


namespace ServiceHub.Api.Endpoints;

public static class ClienteEndpoint
{

    public static RouteGroupBuilder AddClienteEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("criar", async (CriarClienteCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Criar Cliente");
        
        group.MapPatch("atualizar/{id}", async (string id, Request request, ISender sender) =>
        {
            
            var result = await sender.Send(new AtualizarClienteCommand(id,  request.nome, request.cpf_cnpj, request.email, request.telefone, request.endereco, request.complemento, request.numero, request.cep, request.bairro, request.id_cidade));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        }).WithDescription("Atualizar Cliente");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverClienteCommand(id));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Cliente");

        group.MapGet("buscar", async ([AsParameters] BuscarClienteQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        }).WithDescription("Buscar Clientes");

        group.RequireAuthorization();
        
        return group;
    }
}