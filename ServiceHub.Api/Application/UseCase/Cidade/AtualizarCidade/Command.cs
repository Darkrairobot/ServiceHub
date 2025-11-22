using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cidade.AtualizarCidade;

public record Command(string id_cidade, string? nome, string? uf, string? cep, string? ibge) : IRequest<Result>;