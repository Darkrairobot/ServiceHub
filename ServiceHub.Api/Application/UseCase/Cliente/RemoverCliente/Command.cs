using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cliente.RemoverCliente;

public record Command(string id_cliente) : IRequest<Result>;