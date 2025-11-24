using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class CidadeMap : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasMaxLength(36);
        
        builder.Property(c => c.Id_Usuario).HasMaxLength(36).IsRequired();
        
        builder.HasOne(c => c.Usuario).WithMany().HasForeignKey(c => c.Id_Usuario).IsRequired();

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
        
        builder.HasIndex(c => c.Ibge);
        
    }
    
}