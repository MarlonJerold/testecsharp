using backend.Data;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositorio;

public class UsuarioRepositorio : IUsuarioRepository
{
    private PostoContext context;

    public UsuarioRepositorio(PostoContext _context)
    
    {
        context = _context  ?? throw new ArgumentNullException(nameof(context));

    }

    public async Task AddUsuario(Usuario usuario)
    {
        await context.Usuario.AddAsync(usuario);
        await context.SaveChangesAsync();
    }

    public async Task<Usuario?> GetUsuarioPorID(int id)
    {
        return await context.Usuario.FindAsync(id);
    }

    public Usuario? GetUsuarioPorUserName(string userName)
    {
        return context.Usuario.FirstOrDefault(u => u.Nome == userName);
    }


}
