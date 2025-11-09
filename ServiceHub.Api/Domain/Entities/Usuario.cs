namespace ServiceHub.Api.Domain.Entities;

public class Usuario
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public string  Cep { get; set; }
    public string Id_Cidade { get; set; }
    public Cidade Cidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }

    public Usuario(string nome, string email, string telefone, string endereco, string bairro, string numero, string cep, string Id_Cidade)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Bairro = bairro;
        Numero = numero;
        Cep = cep;
        this.Id_Cidade = Id_Cidade;
    }
}