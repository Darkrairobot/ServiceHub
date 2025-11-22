using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Entities;

public class Cliente
{
    public string Id { get; set; }
    public string Id_Usuario { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string Nome { get; set; }
    
    public string Cpf_cnpj { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Complemento { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string Bairro { get; set; }
    public string Id_Cidade { get; set; }
    public Cidade Cidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Cliente(string Id_Usuario,  string nome, string cpf_cnpj, string email, string telefone, string endereco, string complemento,  string numero,  string cep, string bairro, string Id_Cidade)
    {
        Id  = Guid.NewGuid().ToString();
        this.Id_Usuario = Id_Usuario;
        Nome = nome;
        Cpf_cnpj = cpf_cnpj;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Complemento = complemento;
        Numero = numero;
        Cep = cep;
        Bairro = bairro;
        this.Id_Cidade = Id_Cidade;
    }

    public void Atualizar(
        string? nome = null,
        string? cpf_cnpj = null,
        string? email = null,
        string? telefone = null,
        string? endereco = null,
        string? complemento = null,
        string? numero = null,
        string? cep = null,
        string? bairro = null,
        string? id_cidade = null)
    {
        if(nome is not null) Nome = nome;
        if(cpf_cnpj is not null) Cpf_cnpj = cpf_cnpj;
        if(email is not null) Email = email;
        if(telefone is not null) Telefone = telefone;
        if(endereco is not null) Endereco = endereco;
        if(complemento is not null) Complemento = complemento;
        if(numero is not null) Numero = numero;
        if(cep is not null) Cep = cep;
        if(bairro is not null) Bairro = bairro;
        if(id_cidade is not null) Id_Cidade = id_cidade;
    }
    
    
    
}