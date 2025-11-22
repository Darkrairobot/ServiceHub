using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Entities;

public class Cidade
{
    public string Id { get; set; } 
    public string Id_Usuario { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string Nome { get; set; }
    public string Uf { get; set; }
    public string Cep { get; set; }
    public string Ibge { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Cidade(string Id_Usuario, string nome, string uf, string cep, string ibge)
    {
        Id  = Guid.NewGuid().ToString();
        Nome = nome;
        Uf = uf;
        Cep = cep;
        Ibge = ibge;
        this.Id_Usuario = Id_Usuario;
    }

    public void Atualizar(string? nome = null, string? uf = null, string? cep = null, string? ibge = null)
    {
        if(nome is not null) Nome = nome;
        if(uf is not null) Uf = uf;
        if(cep is not null) Cep = cep;
        if(ibge is not null) Ibge = ibge;
    }
    
}