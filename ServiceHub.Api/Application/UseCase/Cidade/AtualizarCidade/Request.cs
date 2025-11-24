namespace ServiceHub.Api.Application.UseCase.Cidade.AtualizarCidade;

public record Request(string? nome, string? uf, string? cep, string? ibge);