using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Venda.CriarVenda;

public record Command(string id_cliente, string id_servico, string endereco, string complemento, string numero, string cep, string bairro, string id_cidade) :  IRequest<Result>;