using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cidade.DeletarCidade;

public record Command(string id_cidade) : IRequest<Result>;