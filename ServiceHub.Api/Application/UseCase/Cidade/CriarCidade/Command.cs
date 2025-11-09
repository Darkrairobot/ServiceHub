using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cidade.CriarCidade;

public record Command(string nome, string uf, string cep, string ibge) : IRequest<Result>;