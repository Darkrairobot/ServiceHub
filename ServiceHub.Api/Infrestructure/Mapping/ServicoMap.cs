using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class ServicoMap : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasMaxLength(36);

        builder.HasOne(s => s.Usuario).WithMany().HasForeignKey(s => s.Id_Usuario);
        
        builder.Property(s => s.Nome).HasMaxLength(100).IsRequired();
        
        builder.Property(s => s.Descricao).HasMaxLength(500).IsRequired();
        
        builder.Property(s => s.Valor).HasPrecision(18, 2).IsRequired();
        
        builder.Property(s => s.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");
    }
}