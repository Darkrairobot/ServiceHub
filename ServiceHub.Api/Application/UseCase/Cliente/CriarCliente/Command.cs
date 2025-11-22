using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Cliente.CriarCliente;

public record Command(string nome, string cpf_cnpj,string email,  string telefone, string endereco, string complemento, string numero, string cep, string bairro, string id_cidade) : IRequest<Result>
{
    
}