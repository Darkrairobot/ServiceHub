using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cliente.BuscarCliente;

public record Query(int pagina = 1, int tamanhoPagina = 10) : IRequest<Result<Response>>;