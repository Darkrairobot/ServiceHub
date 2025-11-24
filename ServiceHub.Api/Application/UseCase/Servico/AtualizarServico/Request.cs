namespace ServiceHub.Api.Application.UseCase.Servico.AtualizarServico;

public record Request(string? nome, string? descricao, decimal? valor);