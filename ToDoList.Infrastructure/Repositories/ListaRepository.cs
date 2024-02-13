using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories;

public class ListaRepository : IListaRepository
{
    private readonly ApplicationDbContext _db;

    public ListaRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AtualizarAsync(Lista lista)
    {
        _db.Listas.Update(lista);
        await _db.SaveChangesAsync();
    }

    public async Task CriarAsync(Lista lista)
    {
        _db.Listas.Add(lista);
        await _db.SaveChangesAsync();
    }

    public async Task<Lista> ObterListaPorIdAsync(int id)
    {
        return await _db.Listas.FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<Lista>> ObterListasDoUsuarioAsync(int idUsuario)
    {
        return await _db.Listas.ToListAsync();
    }

    public async Task RemoverAsync(Lista lista)
    {
        _db.Listas.Remove(lista);
        await _db.SaveChangesAsync();
    }
}