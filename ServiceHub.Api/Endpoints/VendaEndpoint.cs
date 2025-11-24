using MediatR;
namespace ServiceHub.Api.Endpoints;

using CriarVendaCommand = ServiceHub.Api.Application.UseCase.Venda.CriarVenda.Command;
using RemoverVendaCommand = ServiceHub.Api.Application.UseCase.Venda.RemoverVenda.Command;
using BuscarVendaQuery = ServiceHub.Api.Application.UseCase.Venda.BuscarVenda.Query;


public static class VendaEndpoint
{

    public static RouteGroupBuilder AddVendaEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("criar", async (CriarVendaCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        });

        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverVendaCommand(id));
            
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        });

        group.MapGet("buscar", async ([AsParameters] BuscarVendaQuery query,  ISender sender) =>
        {
            var result = await sender.Send(query);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        });

        group.RequireAuthorization();
        
        return group;
    }
    
}