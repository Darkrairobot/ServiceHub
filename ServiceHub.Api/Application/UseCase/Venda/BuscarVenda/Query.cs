using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Venda.BuscarVenda;

public record Query(int pagina = 1, int paginaTamanho = 10) : IRequest<Result<Response>>;