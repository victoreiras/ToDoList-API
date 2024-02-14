using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface ITarefaRepository
{
    Task<Tarefa> ObterTarefaPorIdAsync(int idTarefa);
    Task CriarAsync(Tarefa tarefa);
    Task AtualizarAsync(Tarefa tarefa);
    Task ExcluirTarefaAsync(Tarefa tarefa);
}