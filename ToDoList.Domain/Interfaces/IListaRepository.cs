using ToDoList.Domain.Entities;

namespace ToDoList.Domain.interfaces;

public interface IListaRepository
{
    Task<List<Lista>> ObterListasDoUsuarioAsync(int idUsuario);
    Task<Lista> ObterListaPorIdAsync(int id);
    Task CriarAsync(Lista lista);
    Task AtualizarAsync(Lista lista);
    Task RemoverAsync(Lista lista);
}