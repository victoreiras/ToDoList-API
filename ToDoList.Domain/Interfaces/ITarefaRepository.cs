using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface ITarefaRepository
{
    List<Tarefa> ObterTarefasDeUmaLista(int idLista);
    void Criar(Tarefa tarefa);
    void Atualizar(Tarefa tarefa);
}