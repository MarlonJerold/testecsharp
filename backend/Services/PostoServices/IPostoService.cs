using backend.Dtos;
using backend.models;

namespace backend.Services.PostoServices;

public interface IPostoService
{
    Task<Posto> CriarPosto(PostoDtoRequest novoPosto);
    Task<List<Posto>> ObterTodosOsPostos();
    Task<Posto> ObterPostoPorId(Guid id);
    Task AtualizarPosto(Guid id, string novoNome);
    Task DeletePostoAsync(Guid id);
    
}
