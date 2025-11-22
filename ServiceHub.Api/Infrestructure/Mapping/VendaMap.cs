using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class VendaMap : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id).HasMaxLength(36);
        
        builder.Property(v => v.Id_Servico).HasMaxLength(36).IsRequired();
        
        builder.Property(v => v.Id_Cidade).HasMaxLength(36).IsRequired();
        
        builder.Property(v => v.Id_Usuario).HasMaxLength(36).IsRequired();
        
        builder.Property(v => v.Id_Cliente).HasMaxLength(36).IsRequired();
        
        builder.HasOne(v => v.Usuario).WithMany().HasForeignKey(s => s.Id_Usuario).OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(v => v.Servico).WithMany().HasForeignKey(s => s.Id_Servico).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.Cidade).WithMany().HasForeignKey(s => s.Id_Cidade).OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(v => v.Cliente).WithMany().HasForeignKey(s => s.Id_Cliente).OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(v => v.Endereco).HasMaxLength(200).IsRequired();
        
        builder.Property(v => v.Numero).HasMaxLength(10).IsRequired();
        
        builder.Property(v => v.Complemento).HasMaxLength(150).IsRequired();
        
        builder.Property(v => v.Cep).HasMaxLength(8).IsRequired();

        builder.Property(v => v.Bairro).HasMaxLength(100).IsRequired();
        
        builder.Property(e => e.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");

    }
}