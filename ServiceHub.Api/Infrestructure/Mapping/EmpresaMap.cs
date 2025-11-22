using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class EmpresaMap : IEntityTypeConfiguration<Empresa>
{

    public void Configure(EntityTypeBuilder<Empresa> builder)
    {

        // Chave primária
        builder.HasKey(e => e.Id);

        // Propriedades
        builder.Property(e => e.Id)
            .HasMaxLength(36);
        
        builder.Property(e => e.Id_Cidade).IsRequired().HasMaxLength(36);
        
        builder.Property(e => e.Id_Usuario).IsRequired().HasMaxLength(36);

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(e => e.Cnpj)
            .IsRequired()
            .HasMaxLength(18);

        builder.Property(e => e.Telefone)
            .IsRequired().HasMaxLength(14);

        builder.Property(e => e.Endereco)
            .HasMaxLength(200);
        
        builder.Property(c => c.Complemento)
            .HasMaxLength(150);

        builder.Property(e => e.Bairro)
            .HasMaxLength(100);

        builder.Property(c => c.Numero)
            .HasMaxLength(10).IsRequired();

        builder.Property(e => e.Cep)
            .IsRequired().HasMaxLength(8);

        builder.Property(e => e.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");
        
        builder.HasOne(e => e.Cidade)
            .WithMany() 
            .HasForeignKey(e => e.Id_Cidade)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(e => e.Cnpj)
            .IsUnique();
        
        builder.HasOne(e => e.Usuario)
            .WithMany()
            .HasForeignKey(e => e.Id_Usuario)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);
        
    }
    
}