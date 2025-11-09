using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Empresa.CriarEmpresa;

public record Command(string nome, string cnpj, string telefone, string endereco, string bairro, string numero, string cep, string id_cidade) : IRequest<Result>;