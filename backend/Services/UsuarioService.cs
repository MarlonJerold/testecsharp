using backend.models;
using backend.Repositorio;

namespace backend.Services;

public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepository usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }

    public async Task Add(Usuario usuario)
    {
        await usuarioRepository.AddUsuario(usuario);
    }

    public Task<Usuario?> GetUsuarioPorID(int id)
    {
        return usuarioRepository.GetUsuarioPorID(id);
    }
}
