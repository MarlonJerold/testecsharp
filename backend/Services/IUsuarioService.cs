using backend.models;

namespace backend.Services;

public interface IUsuarioService
{
    Task Add(Usuario usuario);
    Task<Usuario?> GetUsuarioPorID(int id);

}
