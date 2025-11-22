using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Servico.RemoverServico;

public record Command(string id_servico) : IRequest<Result>;