using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface IListaRepository
{
    void Criar(Lista lista);
    void Atualizar(Lista lista);
    void Remover(Lista lista);
}