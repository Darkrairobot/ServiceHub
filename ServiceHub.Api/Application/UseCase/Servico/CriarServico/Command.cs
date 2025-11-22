using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Servico.CriarServico;

public record Command(string nome, string descricao, decimal valor) : IRequest<Result>;