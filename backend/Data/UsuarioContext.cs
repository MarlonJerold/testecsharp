using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class UsuarioContext : DbContext
{
    private readonly string _connectionString;

    protected UsuarioContext(DbContextOptions<UsuarioContext> options)
        : base(options)
    {

    }

    public DbSet<Usuario> Usuario {get; set;}

    

}
