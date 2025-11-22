using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Venda.RemoverVenda;

public record Command(string id_venda) : IRequest<Result>;