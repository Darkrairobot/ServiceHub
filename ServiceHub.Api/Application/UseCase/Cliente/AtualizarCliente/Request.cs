namespace ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente;

public record Request(string id_cliente,
    string? nome,
    string? cpf_cnpj,
    string? email,
    string? telefone,
    string? endereco,
    string? complemento,
    string? numero,
    string? cep,
    string? bairro,
    string? id_cidade);