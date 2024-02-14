using System.Data.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly ApplicationDbContext _db;

    public TarefaRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _db.Tarefas.Update(tarefa);
        await _db.SaveChangesAsync();
    }

    public async Task CriarAsync(Tarefa tarefa)
    {
        _db.Tarefas.Add(tarefa);
        await _db.SaveChangesAsync();
    }
}