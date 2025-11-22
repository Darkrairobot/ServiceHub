using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Servico.AtualizarServico;

public record Command(string id_servico, string? nome, string? descricao, decimal? valor) :  IRequest<Result>; 