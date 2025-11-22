using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente;

public record Command(
    string id_cliente,
    string? nome,
    string? cpf_cnpj,
    string? email,
    string? telefone,
    string? endereco,
    string? complemento,
    string? numero,
    string? cep,
    string? bairro,
    string? id_cidade) : IRequest<Result>;