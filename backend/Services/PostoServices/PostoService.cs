using AutoMapper;
using backend.Data;
using backend.Dtos;
using backend.models;
using backend.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PostoServices;

public class PostoService : IPostoService
{
    private readonly IPostoRepository _postoRepository;
    private readonly PostoContext _context;
    private readonly IMapper _mapper;


    public PostoService(IPostoRepository postoRepository, PostoContext context, IMapper mapper)
    {
        _postoRepository = postoRepository;
        _context = context;
        _mapper = mapper;
    }

    public Task AtualizarPosto(Guid id, string novoNome)
    {
        return _postoRepository.UpdatePostoAsync(id, novoNome);
    }

    public async Task<Posto> CriarPosto(PostoDtoRequest posto)
    {   
        var op = _mapper.Map<Posto>(posto);
        _postoRepository.AddPosto(op);
        return op;
    }   

    public async Task DeletePostoAsync(Guid id)
    {
        var canDelete = await CanDeletePostoAsync(id);

        if (!canDelete)
        {
            throw new InvalidOperationException("Não é possível excluir o posto pois existem vacinas associadas.");
        }

        _postoRepository.DeletePostoAsync(id);
    }

    public async Task<bool> CanDeletePostoAsync(Guid id)
    {
        var posto = await _context.Posto.Include(p => p.Vacinas).FirstOrDefaultAsync(p => p.Id == id);

        if (posto == null)
        {
            return false;
        }

        return posto.Vacinas == null || posto.Vacinas.Count == 0;
    }

    public Task<Posto> ObterPostoPorId(Guid id) => _postoRepository.GetPostoByIdAsync(id);

    public Task<List<Posto>> ObterTodosOsPostos()
    {
        return _postoRepository.GetPostosAsync();
    }
}
