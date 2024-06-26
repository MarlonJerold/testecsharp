using backend.Data;
using backend.models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositorio.VacinaRepositorio;

public class VacinaRepository : IVacinaRepository 
{
    

    public PostoContext _context;

    public VacinaRepository(PostoContext context)
    {
        _context = context;
    }

    public async Task Create(Vacina vacina)
    {
        if (_context == null)
        {
            throw new InvalidOperationException("O contexto do banco de dados não foi inicializado.");
        }
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.Vacinas.AddAsync(vacina);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Falha ao criar vacina. Transação revertida.", ex);
            }
        }
    }

    public async Task Delete(Guid id)
    {
        var vacina = await _context.Vacinas.FindAsync(id);
        if (vacina != null)
        {
            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Vacina>> GetAll()
    {
        return await _context.Vacinas.ToListAsync();
    }

    public async Task<Vacina> GetById(Guid id)
    {
        return await _context.Vacinas.FindAsync(id);
    }

    public async Task Update(Guid id, string novoNome)
    {
        var vacina = await _context.Vacinas.FindAsync(id);
        if (vacina != null)
        {
            vacina.Name = novoNome;
            await _context.SaveChangesAsync();
        }
    }
}


