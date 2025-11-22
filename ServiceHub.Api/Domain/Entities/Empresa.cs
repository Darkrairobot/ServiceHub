using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Entities;

public class Empresa
{
    public string Id { get; set; }
    public string Id_Usuario { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public Cidade Cidade { get; set; }
    public string Id_Cidade { get; set; }
    public string Cep { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Empresa(string Id_Usuario, string nome, string cnpj, string telefone, string endereco, string complemento,string bairro, string numero, string Id_Cidade, string cep)
    {
        Id = Guid.NewGuid().ToString();
        this.Id_Usuario = Id_Usuario;
        Nome = nome;
        Complemento = complemento;
        Cnpj = cnpj;
        Telefone = telefone;
        Endereco = endereco;
        Bairro = bairro;
        Numero = numero;
        this.Id_Cidade = Id_Cidade;
        Cep = cep;
    }

    public void Atualizar(string? nome = null,
        string? cnpj = null,
        string? telefone = null,
        string? endereco = null,
        string? complemento = null,
        string? bairro = null,
        string? numero = null,
        string? cep = null,
        string? id_cidade = null)
    {
        
        if(nome is not null) Nome = nome;
        if(cnpj is not null) Cnpj = cnpj;
        if(telefone is not null) Telefone = telefone;
        if(endereco is not null) Endereco = endereco;
        if(complemento is not null) Complemento = complemento;
        if(bairro is not null) Bairro = bairro;
        if(numero is not null) Numero = numero;
        if(cep is not null) Cep = cep;
        if(id_cidade is not null) Id_Cidade = id_cidade;
    }
    
}