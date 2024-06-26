using backend.models;

namespace backend.Services.VacinaServices;

public interface IVacinaService
{
    Task CriarVacina(Vacina vacina);
    Task<List<Vacina>> ObterTodasVacinas();
    Task<Vacina> ObterPostoPorId(Guid id);
    Task AtualizarVacina(Guid id, string novoNome);
    Task DeletarVacina(Guid id);
}
