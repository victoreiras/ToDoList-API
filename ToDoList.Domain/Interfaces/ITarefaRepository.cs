using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface ITarefaRepository
{
    void Criar(Tarefa tarefa);
    void Atualizar(Tarefa tarefa);
}