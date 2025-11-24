using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasMaxLength(36);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(c => c.Cpf_cnpj).HasMaxLength(18).IsRequired();

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Telefone)
            .HasMaxLength(14);

        builder.Property(c => c.Endereco)
            .HasMaxLength(200);

        builder.Property(c => c.Complemento)
            .HasMaxLength(150);

        builder.Property(c => c.Cep)
            .HasMaxLength(8);

        builder.Property(c => c.Bairro)
            .HasMaxLength(100);

        builder.Property(c => c.Numero)
            .HasMaxLength(10);
        
        builder.Property(c => c.Id_Cidade)
            .IsRequired()
            .HasMaxLength(36);
        
        builder.Property(c => c.Id_Usuario)
            .IsRequired()
            .HasMaxLength(36);
        
        builder.HasOne(c => c.Usuario).WithMany().HasForeignKey(c => c.Id_Usuario).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Cidade)
            .WithMany()                 
            .HasForeignKey(c => c.Id_Cidade)
            .OnDelete(DeleteBehavior.Restrict);

        // Datas
        builder.Property(e => e.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        // Índices recomendados
        builder.HasIndex(c => c.Email);

        builder.HasIndex(c => c.Id_Usuario);
        
    }
}