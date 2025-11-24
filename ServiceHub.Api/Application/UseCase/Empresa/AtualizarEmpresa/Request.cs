namespace ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa;

public record Request(string? nome, string?  cnpj, string telefone, string? endereco, string? complemento, string? bairro, string? numero, string? cep, string? id_cidade);