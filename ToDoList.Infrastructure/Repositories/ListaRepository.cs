using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories;

public class ListaRepository : IListaRepository
{
    private readonly ApplicationDbContext _db;
    private readonly ICacheRepository _cache;

    public ListaRepository(ApplicationDbContext db, ICacheRepository cacheService)
    {
        _db = db;
        _cache = cacheService;
    }

    public void Atualizar(Lista lista)
    {
        throw new NotImplementedException();
    }

    public void Criar(Lista lista)
    {
        throw new NotImplementedException();
    }

    public Lista ObterListaPorId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Lista>> ObterListasDoUsuarioAsync(int idUsuario)
    {
        return await _db.Listas.ToListAsync();
    }

    public void Remover(Lista lista)
    {
        throw new NotImplementedException();
    }
}