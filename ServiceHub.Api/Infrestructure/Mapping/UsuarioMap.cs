using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{

    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .IsRequired()
            .HasMaxLength(450);

        builder.HasOne<ApplicationUser>().WithOne().HasForeignKey<Usuario>(u => u.Id).OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Telefone)
            .HasMaxLength(14);

        builder.Property(u => u.Endereco)
            .HasMaxLength(150);

        builder.Property(u => u.Bairro)
            .HasMaxLength(60);

        builder.Property(u => u.Numero)
            .HasMaxLength(10);

        builder.Property(u => u.Cep)
            .HasMaxLength(8);

        builder.Property(u => u.DataCadastro)
            .IsRequired().HasDefaultValueSql("GETDATE()");

        builder.Property(u => u.DataAlteracao)
            .IsRequired().HasDefaultValueSql("GETDATE()");
        
        builder.HasOne(u => u.Cidade)
            .WithMany() 
            .HasForeignKey(u => u.Id_Cidade)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);;
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
    
}