using backend.models;

namespace backend.Repositorio.VacinaRepositorio;

public interface IVacinaRepository 
{
    Task Create(Vacina posto);
    Task<List<Vacina>> GetAll();
    Task<Vacina> GetById(Guid id);
    Task Update (Guid id, string novoNome);
    Task Delete(Guid id);
}
