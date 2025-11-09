namespace ServiceHub.Api.Domain.Entities;

public class Cidade
{
    public string Id { get; set; } 
    public string Nome { get; set; }
    public string Uf { get; set; }
    public string Cep { get; set; }
    public string Ibge { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Cidade(string nome, string uf, string cep, string ibge)
    {
        Id  = Guid.NewGuid().ToString();
        Nome = nome;
        Uf = uf;
        Cep = cep;
        Ibge = ibge;
    }
}