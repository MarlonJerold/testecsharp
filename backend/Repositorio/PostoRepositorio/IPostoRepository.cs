using backend.models;

namespace backend.Repositorio;

public interface IPostoRepository 
{
    void AddPosto(Posto posto);
    Task<List<Posto>> GetPostosAsync();
    Task<Posto> GetPostoByIdAsync(Guid id);
    Task UpdatePostoAsync (Guid id, string novoNome);
    Task DeletePostoAsync(Guid id);
}

