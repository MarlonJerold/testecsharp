using backend.models;
using backend.Repositorio.VacinaRepositorio;
using backend.Services.PostoServices;

namespace backend.Services.VacinaServices;

public class VacinaService : IVacinaService
{
    private readonly IVacinaRepository _vacinaRepository;
    private readonly IPostoService _postoServices;

    
    public VacinaService(IVacinaRepository vacinaRepository, IPostoService postoServices)
    {
        _vacinaRepository = vacinaRepository;
        _postoServices = postoServices;
    }

    public Task AtualizarVacina(Guid id, string novoNome) => _vacinaRepository.Update(id, novoNome);

    public async Task CriarVacina(Vacina vacina)
    {
        if (vacina.Validade <= DateTime.Today)
        {
            throw new ArgumentException("A data de validade deve ser no futuro.");
        }

        Posto posto = await _postoServices.ObterPostoPorId(vacina.PostoId);
        
        if (posto == null)
        {
            throw new  InvalidOperationException($"Posto com id '{vacina.PostoId}' não encontrado.");
        }

        vacina.PostoId = posto.Id;
        await _vacinaRepository.Create(vacina);
        
    }

    public async Task DeletarVacina(Guid id)
    {
        var vacina = await ObterPostoPorId(id);

        if (vacina == null)
        {
            throw new InvalidOperationException("Vacina mecionada não existe");
        }
        _ = _vacinaRepository.Delete(id);
    }

    public async Task<Vacina> ObterPostoPorId(Guid id)
    {
       var vacina = await _vacinaRepository.GetById(id) ?? throw new InvalidOperationException("Vacina mecionada não existe");
       return vacina ;
    }

    public Task<List<Vacina>> ObterTodasVacinas()
    {
        return _vacinaRepository.GetAll();
    }
}
