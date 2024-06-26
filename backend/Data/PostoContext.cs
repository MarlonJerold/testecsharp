using backend.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace backend.Data;

public class PostoContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Posto> Posto { get; set; }
    public DbSet<Vacina> Vacinas { get; set; }
    public DbSet<Usuario> Usuario {get; set;}

    public PostoContext(DbContextOptions<PostoContext> options)
        : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posto>()
            .HasMany(e => e.Vacinas)
            .WithOne(e => e.Posto)
            .HasForeignKey(e => e.PostoId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Posto>()
            .HasIndex(e => e.Name)
            .IsUnique();
    }
    
}
