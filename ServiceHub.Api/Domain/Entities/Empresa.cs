namespace ServiceHub.Api.Domain.Entities;

public class Empresa
{
    public string Id { get; set; }
    public string Id_Usuario { get; set; }
    public Usuario Usuario { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public Cidade Cidade { get; set; }
    public string Id_Cidade { get; set; }
    public string Cep { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Empresa(string Id_Usuario, string nome, string cnpj, string telefone, string endereco, string bairro, string numero, string Id_Cidade, string cep)
    {
        Id = Guid.NewGuid().ToString();
        this.Id_Usuario = Id_Usuario;
        Nome = nome;
        Cnpj = cnpj;
        Telefone = telefone;
        Endereco = endereco;
        Bairro = bairro;
        Numero = numero;
        this.Id_Cidade = Id_Cidade;
        Cep = cep;
    }
    
}