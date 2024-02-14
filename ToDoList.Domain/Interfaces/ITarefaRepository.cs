using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface ITarefaRepository
{
    //List<Tarefa> ObterTarefasDeUmaLista(int idLista);
    Task CriarAsync(Tarefa tarefa);
    Task AtualizarAsync(Tarefa tarefa);
}