using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Domain.Entities;

public class Servico
{
    public string Id { get; set; }
    public string Id_Usuario { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Servico(string Id_Usuario, string nome,  string descricao, decimal valor)
    {
        Id  = Guid.NewGuid().ToString();
        this.Id_Usuario = Id_Usuario;
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
    }

    public void Atualizar(string? nome = null, string? descricao = null, decimal? valor = null)
    {
        if(nome is not null) Nome = nome;
        if(descricao is not null) Descricao = descricao;
        if(valor is not null) Valor = valor.Value;
    }
    
}