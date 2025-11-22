using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cidade.BuscarCidade;

public record Query(string? nome, string? ibge, string? uf, int pagina = 1, int tamanhoPagina = 10) : IRequest<Result<Response>>;