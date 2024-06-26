using backend.models;

namespace backend.Repositorio;

public interface IUsuarioRepository 
{
    Task AddUsuario(Usuario usuario);
    Task<Usuario?> GetUsuarioPorID(int id);
    Usuario? GetUsuarioPorUserName(string userName);
}
