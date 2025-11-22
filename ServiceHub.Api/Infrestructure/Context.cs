using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Entities;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure;

public class Context : IdentityDbContext<ApplicationUser>
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Cidade> Cidade { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Servico> Servico { get; set; }
    
    public DbSet<Venda> Venda { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
    
    
}