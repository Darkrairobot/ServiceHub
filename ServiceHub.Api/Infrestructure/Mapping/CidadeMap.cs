using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class CidadeMap : IEntityTypeConfiguration<Cidade>
{

    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        
        builder.ToTable("Cidade");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Uf)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(c => c.Cep)
            .IsRequired().HasMaxLength(8);

        builder.Property(c => c.Ibge)
            .IsRequired().HasMaxLength(7);

        builder.Property(c => c.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");
        
        builder.HasIndex(c => c.Ibge).IsUnique();
        
    }
    
}