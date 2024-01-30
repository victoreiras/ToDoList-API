using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface IListaRepository
{
    Task<List<Lista>> ObterListasDoUsuarioAsync(int idUsuario);
    Lista ObterListaPorId(int id);
    void Criar(Lista lista);
    void Atualizar(Lista lista);
    void Remover(Lista lista);
}