using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Entities;

public class Venda
{
    public string Id { get; set; }
    public string Id_Cliente { get; set; }
    public Cliente Cliente { get; set; }
    public string Id_Usuario { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string Id_Servico { get; set; }
    public Servico Servico { get; set; }
    public string Endereco { get; set; }
    public string Complemento { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string Bairro { get; set; }
    public string Id_Cidade { get; set; }
    public Cidade Cidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Venda(string Id_Usuario, string Id_Cliente,  string Id_Servico, string endereco, string complemento,  string numero, string cep, string bairro, string Id_Cidade)
    {
        Id = Guid.NewGuid().ToString();
        this.Id_Usuario = Id_Usuario;
        this.Id_Cliente = Id_Cliente;
        this.Id_Servico = Id_Servico;
        Endereco = endereco;
        Complemento = complemento;
        Numero = numero;
        Cep = cep;
        Bairro = bairro;
        this.Id_Cidade = Id_Cidade;
    }
}