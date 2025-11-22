using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa;

public record Command(string id_empresa, string? nome, string?  cnpj, string telefone, string? endereco, string? complemento, string? bairro, string? numero, string? cep, string? id_cidade) : IRequest<Result>;