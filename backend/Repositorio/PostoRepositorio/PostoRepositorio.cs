using backend.Data;
using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositorio.PostoRepositorio;

public class PostoRepositorio : IPostoRepository
{

    private readonly PostoContext _context;

    public PostoRepositorio(PostoContext context)
    {
        _context = context;
    }
    
    public void AddPosto(Posto posto)
    {
        _context.Posto.Add(posto);
        _context.SaveChanges();
    }

    public async Task<List<Posto>> GetPostosAsync()
    {
        return await _context.Posto
            .Include(p => p.Vacinas) // Inclui as vacinas relacionadas ao posto
            .ToListAsync(); 
    }

    public async Task<Posto> GetPostoByIdAsync(Guid id)
    {
        return await _context.Posto.FindAsync(id);
    }

    public async Task UpdatePostoAsync(Guid id, string novoNome)
    {
        var posto = await _context.Posto.FindAsync(id);
        if (posto != null)
        {
            posto.Name = novoNome;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeletePostoAsync(Guid id)
    {
        var posto = await _context.Posto.FindAsync(id);
        if (posto != null)
        {
            _context.Posto.Remove(posto);
            _context.SaveChangesAsync();
        }
    }

}
