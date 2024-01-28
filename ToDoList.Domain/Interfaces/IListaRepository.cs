using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface IListaRepository
{
    List<Lista> ObterListasDoUsuario(int idUsuario);
    Lista ObterListaPorId(int id);
    void Criar(Lista lista);
    void Atualizar(Lista lista);
    void Remover(Lista lista);
}